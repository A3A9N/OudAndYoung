using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private bool isChild = true;
    [SerializeField] private float moveSpeed = 5f;
    private bool isGrounded;

    void Update()
    {
        float move = GetInput();
        transform.Translate(Vector3.right * move * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W) && isGrounded &&isChild)
        {
            Jump();
        }
    }

    private float GetInput()
    {
        KeyCode left = isChild ? KeyCode.A : KeyCode.LeftArrow;
        KeyCode right = isChild ? KeyCode.D : KeyCode.RightArrow;

        if (Input.GetKey(left)) return -1f;
        if (Input.GetKey(right)) return 1f;
        return 0f; 
    }
    private void Jump()
    {
        transform.Translate(Vector3.up * 10f * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.CompareTag("Floor"))
       {
           isGrounded = true;
       }
       else
                   {
           isGrounded = false;
        }
    }
}