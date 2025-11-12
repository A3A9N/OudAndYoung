using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Portal que espera a un jugador específico (playerId).
/// Cuando ambos portals (player1 y player2) estén ocupados al mismo tiempo, carga nextSceneName.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class Portal : MonoBehaviour
{
    public int playerId = 1; // 1 o 2
    public string nextSceneName = "Nivel2";

    // static para compartir estado entre portals
    static bool player1InPortal = false;
    static bool player2InPortal = false;

    private void Awake()
    {
        Collider2D col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerIdentifier pi = other.GetComponent<PlayerIdentifier>();
        if (pi == null) return;
        if (pi.playerId == 1) player1InPortal = true;
        if (pi.playerId == 2) player2InPortal = true;

        CheckBoth();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerIdentifier pi = other.GetComponent<PlayerIdentifier>();
        if (pi == null) return;
        if (pi.playerId == 1) player1InPortal = false;
        if (pi.playerId == 2) player2InPortal = false;
    }

    void CheckBoth()
    {
        if (player1InPortal && player2InPortal)
        {
            // Ambos en sus portals: cargar siguiente escena
            // Puedes añadir anims/sonidos aquí antes de cargar
            SceneManager.LoadScene(nextSceneName);
        }
    }

    // Resetea estado si la escena se carga de nuevo
    private void OnEnable()
    {
        // Opcional: al cargar escena nueva quieres resetear
    }
}
