using UnityEngine;

public class PickUps : MonoBehaviour
{
    [SerializeField] private string TargetTag = "Young";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TargetTag))
        {
            PickUpScoreManager.Instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
