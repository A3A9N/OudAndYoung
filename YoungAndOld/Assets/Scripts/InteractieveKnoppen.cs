using UnityEngine;

public class InteractieveKnoppen : MonoBehaviour
{
    [SerializeField] private Transform cube;           
    [SerializeField] private float moveDistance = 3f;  
    [SerializeField] private float moveDuration = 2f;  
    private bool isPressed = false;
    private bool hasMoved = false;
    private Vector3 cubeStartPos;
    private Vector3 cubeDownPos;

    private void Start()
    {
        cubeStartPos = cube.position;
        cubeDownPos = cubeStartPos - new Vector3(0, moveDistance, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Child"))
        {
            isPressed = true;
            StartCoroutine(MoveCubeDown());
        }

        if (other.CompareTag("OldMan"))
        {
            isPressed = true;
            StartCoroutine(MoveCubeDown());
        }
    }

    private System.Collections.IEnumerator MoveCubeDown()
    {
        hasMoved = true;

        Vector3 start = cube.position;
        Vector3 end = cubeDownPos;
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            cube.position = Vector3.Lerp(start, end, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        cube.position = end;
    }
}
