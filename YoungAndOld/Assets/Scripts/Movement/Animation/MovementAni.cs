using UnityEngine;

public class MovementAni : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private bool isChild = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        bool movingRight = isChild ? Input.GetKey(KeyCode.D) : Input.GetKey(KeyCode.RightArrow);
        bool movingLeft = isChild ? Input.GetKey(KeyCode.A) : Input.GetKey(KeyCode.LeftArrow);

        ResetAnimStates("WalkLeft", "WalkRight", "Idle");

        if (movingRight)
            animator.SetBool("WalkRight", true);
        else if (movingLeft)
            animator.SetBool("WalkLeft", true);
        else
            animator.SetBool("Idle", true);
    }

    private void HandleJump()
    {
        bool frontJump = Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D);
        bool leftJump = Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W);
        bool rightJump = Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W);

        ResetAnimStates("FrontJump", "LeftJump", "RightJump");

        if (leftJump)
            SetJump("LeftJump");
        else if (rightJump)
            SetJump("RightJump");
        else if (frontJump)
            SetJump("FrontJump");
    }

    private void SetJump(string anim)
    {
        animator.SetBool(anim, true);
        animator.SetBool("Idle", false);
    }

    private void ResetAnimStates(params string[] states)
    {
        foreach (string state in states)
            animator.SetBool(state, false);
    }
}