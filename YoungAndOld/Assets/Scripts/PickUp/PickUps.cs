using UnityEngine;

public class PickUps : MonoBehaviour
{
    [SerializeField] private string TargetTag = "Young";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TargetTag))
        {
            PickUpScoreManager.Instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
