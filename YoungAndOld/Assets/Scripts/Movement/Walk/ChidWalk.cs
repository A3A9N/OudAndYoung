using System.Runtime.InteropServices;
using UnityEngine;

public class ChidWalk : MonoBehaviour
{
    [SerializeField] private float jumpForce = 300f;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private float horizontalInput;
    [SerializeField]private bool onGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            transform.position += Vector3.right * horizontalInput * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.W) && onGround)
        {
            transform.Translate(Vector3.up * jumpForce * Time.deltaTime);
            onGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onGround = true;
        }

    }
}
