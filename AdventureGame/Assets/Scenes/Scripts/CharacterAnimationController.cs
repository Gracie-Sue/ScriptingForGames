using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // Cache the Animator component attached to CharacterArt
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleAnimations();
        HandleSpecialActions();
    }

    private void HandleAnimations()
    {
        // Handle running and idling
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetTrigger("Run");
        }
        else
        {
            animator.SetTrigger("Idle");
        }

        // Handle Jumping
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("Jump");
        }

        // Handle wall jumping
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("WallJump");
        }
    }

    private void HandleSpecialActions()
    {
        // Check for the spacebar press to trigger the Double Jump animation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("DoubleJumpTrigger");
        }

        // Check for the F key press to trigger the Fall animation
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("FallTrigger");
        }

        // Check for the H key press to trigger the Hit animation
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetTrigger("HitTrigger");
        }
    }
}