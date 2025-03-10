using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;  // The player body to rotate horizontally
    private float xRotation = 0f; // Vertical camera rotation (up/down)

    void Start()
    {
        // Lock the cursor to the center of the screen when the game starts
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Method to process mouse input (called from InputManager)
    public void ProcessMouseLook(Vector2 input)
    {
        // Mouse X and Y represent horizontal (left-right) and vertical (up-down) movement
        float mouseX = input.x * mouseSensitivity * Time.deltaTime; // Left/Right movement (horizontal)
        float mouseY = input.y * mouseSensitivity * Time.deltaTime; // Up/Down movement (vertical)

        // Rotate the camera vertically (clamped to avoid flipping upside down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Limit vertical rotation to prevent over-rotation

        // Apply vertical rotation to the camera (up/down)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Apply horizontal rotation to the player body (left/right)
        playerBody.Rotate(Vector3.up * mouseX); // Rotate horizontally around the Y-axis (left/right)
    }

    void OnDisable()
    {
        // Unlock the cursor when this script is disabled or when exiting the game
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
