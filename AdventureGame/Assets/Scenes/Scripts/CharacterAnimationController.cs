using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;

    private bool isGrounded = true; // To track if the character is on the ground
    private bool canDoubleJump = false; // To allow only one double jump per jump
    private float lastJumpTime = 0f; // Timer to track time between jumps
    private float doubleJumpTimeWindow = 0.25f; // Time window to detect double jump

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
            animator.SetTrigger("RunTrigger");
        }
        else
        {
            animator.SetTrigger("IdleTrigger");
        }

        // Handle Jumping and Double Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            // First jump
            animator.SetTrigger("JumpTrigger");
            isGrounded = false;  // Set grounded to false immediately after jumping
            canDoubleJump = true; // Allow double jump
            lastJumpTime = Time.time; // Record the time of the first jump
        }
        else if (canDoubleJump && (Time.time - lastJumpTime) <= doubleJumpTimeWindow)
        {
            // Double jump if within the time window and allowed
            animator.SetTrigger("DoubleJumpTrigger");
            canDoubleJump = false; // Disable further double jumps
        }
    }

    private void HandleSpecialActions()
    {
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

    // This method would typically be triggered by collision detection with the ground
    public void OnLanding()
    {
        isGrounded = true;
        canDoubleJump = false; // Reset double jump capability on landing
        animator.SetTrigger("IdleTrigger"); // Transition to Idle when landing
    }

    // Optional: Use OnCollisionEnter or OnTriggerEnter to call OnLanding
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Ensure the object has the "Ground" tag
        {
            OnLanding(); // Call landing method on collision with the ground
        }
    }
}
