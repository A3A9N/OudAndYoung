using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float jumpForce = 8f;

    [Header("Controles")]
    public string horizontalAxis = "Horizontal"; // Eje horizontal
    public string jumpButton = "Jump";           // Botón de salto

    [Header("Detección de suelo")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        float moveX = Input.GetAxis(horizontalAxis);
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        // Saltar si está en el suelo
        if (isGrounded && Input.GetButtonDown(jumpButton))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // Comprobamos si está tocando el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
