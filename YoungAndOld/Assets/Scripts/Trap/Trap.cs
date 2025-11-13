using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float climbForce = 6f;
    private Rigidbody2D rb;
    private bool isInLadderZone = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (CompareTag("Child") && isInLadderZone)
        {

            if (Input.GetKey(KeyCode.W))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, climbForce);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            isInLadderZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            isInLadderZone = false;
        }
    }
}
