using System.Runtime.InteropServices;
using UnityEngine;

public class GrandpaWalk : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float horizontalInput;

    void Update()
    {
        horizontalInput = 0f;
        if (Input.GetKey(KeyCode.RightArrow))
            horizontalInput = 1f;
        else if (Input.GetKey(KeyCode.LeftArrow))
            horizontalInput = -1f;

        if (horizontalInput != 0)
        {
            transform.position += Vector3.right * horizontalInput * moveSpeed * Time.deltaTime;
        }
    }
}