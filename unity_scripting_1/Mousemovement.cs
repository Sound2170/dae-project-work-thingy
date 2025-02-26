using UnityEngine;

public class Mousemovement : MonoBehaviour
{
    public float mouseSensitivity = 2300f;
    

    float yRotation = 0f;
    float xRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //locks the cursor to the middle of the screen and makes it invisable so it wouldn't be a problem when playing.
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        //rotating the X axis. (looking up and down)
        xRotation -= mouseY;
        //clamp rotation
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);
        //rotating the Y axis. (looking left and right)
        yRotation += mouseX; 
        //apply rotations to our transform
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

    }
}
