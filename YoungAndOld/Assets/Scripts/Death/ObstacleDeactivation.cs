using UnityEngine;

public class ObstacleDeactivation : MonoBehaviour
{
    private enum PlayerType { Old, Child };
    [SerializeField] private PlayerType playerType;
    private string oldPlayerTag = "OldMan";
    private string childPlayerTag = "Child";
    private string PlayerTag;
    [SerializeField] private GameObject Obstacle;
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerTag = playerType == PlayerType.Old ? oldPlayerTag : childPlayerTag;
        if (other.tag == PlayerTag)
        {
            Obstacle.SetActive(false);
        }
    }
}
