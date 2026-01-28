// Gives access to core Unity classes like MonoBehaviour, GameObject, etc.
using UnityEngine;

// Gives access to Unity's NEW Input System classes
using UnityEngine.InputSystem;

// This class handles player input and forwards it to other scripts
public class InputManager : MonoBehaviour
{
    // Reference to the auto-generated input actions class
    // This comes from your Input Actions asset
    private PlayerInputActions _playerInputActions;

    // Event that other scripts can subscribe to for jump input
    // No parameters because jumping is just an action (pressed or not)
    public System.Action OnJump;
    
    // Event for movement input
    // Sends a float value (e.g., -1 to 1 for left/right)
    public System.Action<float> OnMove;

    // Awake is called once when the script instance is loaded
    // It runs before Start and before Update
    void Awake()
    {
        // Create a new instance of the input actions class
        _playerInputActions = new PlayerInputActions();

        // Enable all input action maps so they start listening for input
        _playerInputActions.Enable();
    }

    // Called every time this GameObject becomes enabled
    void OnEnable()
    {
        // Subscribe to the Jump action's "performed" event
        // When Jump is pressed, OnJumpPressed will be called
        _playerInputActions.Player.Jump.performed += OnJumpPressed;

        // This was commented out because movement is handled differently
        //_playerInputActions.Player.Horizontal.performed += OnMovement;
    }

    // Called every time this GameObject becomes disabled
    void OnDisable()
    {
        // Unsubscribe from the Jump event
        // This prevents memory leaks and duplicate calls
        _playerInputActions.Player.Jump.performed -= OnJumpPressed;

        // Also commented out for the same reason as above
        //_playerInputActions.Player.Horizontal.performed -= OnMovement;
    }

    // This method is called when the Jump input action is performed
    void OnJumpPressed(InputAction.CallbackContext context)
    {
        // Invoke the OnJump event, but only if something is subscribed to it
        // The ?. prevents a null reference error
        OnJump?.Invoke();
    }

    // Handles movement input
    void OnMovement()
    {
        // Read the float value from the Horizontal input action
        // Example values: -1 (left), 0 (idle), 1 (right)

        // Invoke the movement event and pass the input value
        OnMove?.Invoke(_playerInputActions.Player.Horizontal.ReadValue<float>());
    }

    // Update is called once per frame
    void Update()
    {
        // Continuously read movement input every frame
        // This ensures smooth movement while a key is held down
        OnMovement();
    }
}
