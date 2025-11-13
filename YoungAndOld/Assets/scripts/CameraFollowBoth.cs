using UnityEngine;

/// <summary>
/// Cámara que sigue a dos objetivos (players). 
/// Centra en el punto medio, se suaviza y cambia tamaño ortográfico según la distancia entre jugadores.
/// También permite límites (min/max) para no salir del mapa.
/// </summary>
[RequireComponent(typeof(Camera))]
public class CameraFollowBoth : MonoBehaviour
{
    public Transform playerA;
    public Transform playerB;

    [Header("Follow settings")]
    public float smoothTime = 0.15f;
    public Vector3 offset = new Vector3(0, 0, -10f);

    [Header("Zoom settings")]
    public float minSize = 5f;
    public float maxSize = 10f;
    public float zoomLimiter = 10f; // cuánto afecta la distancia al zoom

    [Header("Bounds (world coordinates)")]
    public Vector2 minCameraPosition;
    public Vector2 maxCameraPosition;

    Camera cam;
    Vector3 velocity = Vector3.zero;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (!cam.orthographic) Debug.LogWarning("CameraFollowBoth funciona mejor con cámara ortográfica para juegos 2D.");
    }

    void LateUpdate()
    {
        if (playerA == null || playerB == null) return;

        // Punto medio entre players
        Vector3 midpoint = (playerA.position + playerB.position) / 2f;

        // Deseada posición (centra, más offset)
        Vector3 desiredPos = new Vector3(midpoint.x, midpoint.y, 0f) + offset;

        // SmoothDamp hacia desiredPos
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothTime);

        // Ajustar zoom según distancia
        float distance = Vector2.Distance(playerA.position, playerB.position);
        float targetSize = Mathf.Lerp(minSize, maxSize, distance / zoomLimiter);
        targetSize = Mathf.Clamp(targetSize, minSize, maxSize);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, Time.deltaTime * 4f);

        // Cuidado: limitar cámara dentro de bounds (ten en cuenta la size y aspecto)
        LimitCameraToBounds();
    }

    void LimitCameraToBounds()
    {
        if (minCameraPosition == Vector2.zero && maxCameraPosition == Vector2.zero) return; // si no pones bounds, no limita

        float vertExtent = cam.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        float leftBound = minCameraPosition.x + horzExtent;
        float rightBound = maxCameraPosition.x - horzExtent;
        float bottomBound = minCameraPosition.y + vertExtent;
        float topBound = maxCameraPosition.y - vertExtent;

        float clampedX = Mathf.Clamp(transform.position.x, leftBound, rightBound);
        float clampedY = Mathf.Clamp(transform.position.y, bottomBound, topBound);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
