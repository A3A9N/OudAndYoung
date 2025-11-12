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
            SetJumpLayerActive(true);

        }
        else if (RightJump)
        {
            animator.SetBool("RightJump", true);
            NoIdle();
            SetJumpLayerActive(true);
        }
        else if(FrontJump)
        {
            animator.SetBool("FrontJump", true);
            NoIdle();
            SetJumpLayerActive(true);
        }
        else if (!FrontJump && !RightJump && !LeftJump)
        {
            SetJumpLayerActive(false);
        }


        void NoIdle()
        {
            animator.SetBool("Idle", false);
        }
        void SetJumpLayerActive(bool active)
        {
            int jumpLayerIndex = animator.GetLayerIndex("Jump Layer");
            animator.SetLayerWeight(jumpLayerIndex, active ? 1f : 0f);
        }
    }
}
