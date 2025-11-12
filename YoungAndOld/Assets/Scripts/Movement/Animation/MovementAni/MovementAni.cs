using UnityEngine;

public class MovementAni : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    private bool isChild = true; 

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        bool movingRight = false;
        bool movingLeft = false;

        if (isChild)
        { 
            movingRight = Input.GetKey(KeyCode.D);
            movingLeft = Input.GetKey(KeyCode.A);
        }
        else
        {
            movingRight = Input.GetKey(KeyCode.RightArrow);
            movingLeft = Input.GetKey(KeyCode.LeftArrow);
        }

        animator.SetBool("WalkLeft", false);
        animator.SetBool("WalkRight", false);
        animator.SetBool("Idle", false);

        if (movingRight)
        {
            animator.SetBool("WalkRight", true);
        }
        else if (movingLeft)
        {
            animator.SetBool("WalkLeft", true);
        }
        else
        {
            animator.SetBool("Idle", true);
        }
    }
}