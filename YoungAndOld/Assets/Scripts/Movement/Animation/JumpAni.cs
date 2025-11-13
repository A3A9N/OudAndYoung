using Unity.VisualScripting;
using UnityEngine;

public class JumpAni : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        bool FrontJump = false;
        bool LeftJump = false;
        bool RightJump = false;

        FrontJump = Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D);
        LeftJump = Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W);
        RightJump = Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W);

        animator.SetBool("FrontJump", false);
        animator.SetBool("LeftJump", false);
        animator.SetBool("RightJump", false);

        if (LeftJump)
        {
            animator.SetBool("LeftJump", true);
            NoIdle();
        }
        else if (RightJump)
        {
            animator.SetBool("RightJump", true);
            NoIdle();
        }
        else if(FrontJump)
        {
            animator.SetBool("FrontJump", true);
            NoIdle();
        }
        void NoIdle()
        {
            animator.SetBool("Idle", false);
        }

    }
}
