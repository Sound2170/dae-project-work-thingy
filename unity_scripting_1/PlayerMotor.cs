using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller; 
    private Vector3 playerVelocity;
    public float speed = 5f;
    private bool isGrounded;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded; // Check grounding inside Update

        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        ProcessMove(input);

        if (Input.GetButtonDown("Jump")) // Calls Jump() when spacebar is pressed
        {
            Jump();
        }
    }

    public void ProcessMove(Vector2 input) 
    {
        // Move the player based on input
        Vector3 moveDirection = transform.right * input.x + transform.forward * input.y;
        controller.Move(moveDirection * speed * Time.deltaTime);

        // Handle gravity and ensure smooth landing
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f; // Small negative value to keep grounded
        }

        // Apply gravity
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Fixed gravity multiplier
        }
    }
}
