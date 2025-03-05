using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
    
    
    // Process look movement with more intuitive control
    public void ProcessLook(Vector2 input)
    {
        // Directly use mouse input without multiplying by Time.deltaTime
        float mouseX = input.x * xSensitivity;
        float mouseY = input.y * ySensitivity;

        // Calculate camera rotation for looking up and down, applying sensitivity
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // Apply the vertical rotation to the camera's local rotation
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Apply horizontal rotation to the player (body)
        transform.Rotate(Vector3.up * mouseX);
    }
}
