using System.Runtime.InteropServices;
using UnityEngine;

public class ChidWalk : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float horizontalInput;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            transform.position += Vector3.right * horizontalInput * moveSpeed * Time.deltaTime;
        }
    }
}
