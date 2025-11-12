using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float fallY = -10f;

    void Update()
    {
        if (player1.position.y < fallY || player2.position.y < fallY)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
