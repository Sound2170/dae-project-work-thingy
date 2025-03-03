using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller; 
    private Vector3 playerVelocity;
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // recive the inputs for our InputManager.cs and apply them to our charcter controller.
    public void ProcessMove(Vector2 input) 
    {

    }
}
