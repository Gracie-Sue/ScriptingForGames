using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = -9.81f;
	

    private CharacterController controller;
    private Vector3 velocity;
    private Transform thisTransform;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        thisTransform = transform;
    }

    private void Update()
    {
        MoveCharacter();
        ApplyGravity();
        KeepCharacterOnAxis();
    }

    private void MoveCharacter()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(moveInput, 0f, 0f);
		controller.Move(move * moveSpeed * Time.deltaTime);

        // Jumping
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    private void ApplyGravity() // Removed semicolon here
    {
        // Apply gravity when not grounded
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime; // Apply gravity
        }
        else if (velocity.y < 0)
        {
            //When grounded, reset the vertical velocity
			velocity.y = -2f;
        }

        // Apply the velocity to the controller
        controller.Move(velocity * Time.deltaTime);
    }

    private void KeepCharacterOnAxis()
    {
        var currentPosition = thisTransform.position;
		currentPosition.z = 0f;
		thisTransform.position = currentPosition;
	}
}