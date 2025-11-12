using UnityEngine;

public class Death : MonoBehaviour
{
    private enum PlayerType { Old, Child };
    private string oldPlayerTag = "OldWeakness";
    private string childPlayerTag = "ChildWeakness";
    [Header("Select Player Type")]
    [SerializeField] private PlayerType playerType;
    private string PlayerWeaknessTag;
    [Header("Death Settings")]
    [SerializeField] private float restartDelay = 1f;
    [SerializeField] private GameObject deathEffect;

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerWeaknessTag = playerType == PlayerType.Old ? oldPlayerTag : childPlayerTag;
        if (collision.tag == PlayerWeaknessTag)
        {
            deathEffect.SetActive(true);
            Destroy(collision.gameObject);
            Invoke("RestartLevel", restartDelay);
        }
    }

    void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
