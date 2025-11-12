using UnityEngine;

/// <summary>
/// Movimiento simple para prototipo: caminar + salto.
/// Usa Input.GetKey para dos players (playerId = 1 -> WASD, playerId = 2 -> Flechas).
/// A�adir este script al prefab del jugador (abuelo / ni�o).
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Player")]
    public int playerId = 1; // 1 = WASD, 2 = Flechas

    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.08f;
    public LayerMask groundLayer;

    // Internal
    Rigidbody2D rb;
    bool isGrounded;
    float horizontal;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (groundCheck == null)
        {
            // crea un punto de ground check bajo el personaje si no existe
            GameObject g = new GameObject("GroundCheck");
            g.transform.parent = transform;
            g.transform.localPosition = new Vector3(0, -0.55f, 0);
            groundCheck = g.transform;
        }
    }

    void Update()
    {
        ReadInput();
        GroundCheck();
        HandleJump();
        ApplyHorizontalMovement();
        FlipSpriteIfNeeded();
    }

    void ReadInput()
    {
        if (playerId == 1)
        {
            // WASD
            horizontal = 0f;
            if (Input.GetKey(KeyCode.A)) horizontal = -1f;
            if (Input.GetKey(KeyCode.D)) horizontal = 1f;
        }
        else
        {
            // Flechas
            horizontal = 0f;
            if (Input.GetKey(KeyCode.LeftArrow)) horizontal = -1f;
            if (Input.GetKey(KeyCode.RightArrow)) horizontal = 1f;
        }
    }

    void ApplyHorizontalMovement()
    {
        Vector2 vel = rb.linearVelocity;
        vel.x = horizontal * moveSpeed;
        rb.linearVelocity = vel;
    }

    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        // opcional: debug
        // Debug.DrawRay(groundCheck.position, Vector3.down * 0.1f, isGrounded ? Color.green : Color.red);
    }

    void HandleJump()
    {
        bool jumpPressed = false;
        if (playerId == 1) jumpPressed = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space);
        else jumpPressed = Input.GetKeyDown(KeyCode.UpArrow);

        if (jumpPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // reset vertical
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void FlipSpriteIfNeeded()
    {
        if (horizontal > 0.01f) transform.localScale = new Vector3(1, 1, 1);
        else if (horizontal < -0.01f) transform.localScale = new Vector3(-1, 1, 1);
    }

    // Para depuraci�n: ver el radio en el editor
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
