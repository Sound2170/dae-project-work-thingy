using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput PlayerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;
    private MouseLook look; 
    
    void Awake()
    {
        PlayerInput = new PlayerInput();
        onFoot = PlayerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<MouseLook>();
        onFoot.Jump.performed += ctx => motor.Jump();
    }
    
    void FixedUpdate()
    {
        // Tell the PlayerMotor to move using the movement input
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    void LateUpdate()
    {
        // Process mouse input for looking around
        look.ProcessMouseLook(onFoot.Look.ReadValue<Vector2>());
    }

    void OnEnable()
    {
        onFoot.Enable();
    }

    void OnDisable()
    {
        onFoot.Disable();  
    }
}
