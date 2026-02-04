// Gives access to Unity’s core classes (MonoBehaviour, Rigidbody2D, etc.)
using UnityEngine;

// Controls player movement and physics reactions based on input
public class PlayerController : MonoBehaviour
{
    // Movement speed multiplier for horizontal movement
    // Serialized so it can be tweaked in the Inspector
    [SerializeField] private float moveSpeed = 10f;

    // Force applied upward when the player jumps
    [SerializeField] private float jumpForce = 15f;

    // Reference to the InputManager that provides input events
    [SerializeField] private InputManager inputManager;

    // Inspector header to group ground-check related variables
    [Header("Ground Check")]
    
    // Layer(s) considered as ground
    [SerializeField] private LayerMask groundLayer;
    
    // Offset from the player’s position where the ground check ray starts
    [SerializeField] private Vector2 startPointOffset;
    
    // How far down the raycast checks for ground
    [SerializeField] private float groundCheckDistance;

    // Stores the current horizontal input value (-1 to 1)
    private float _horizontalInput;

    // Reference to the player’s Rigidbody2D (used for physics movement)
    private Rigidbody2D _playerRb;

    // Tracks whether the player is currently touching the ground
    private bool _isOnGround;

    // Awake is called once when the script is loaded
    void Awake()
    {
        // Cache the Rigidbody2D component attached to this GameObject
        _playerRb = GetComponent<Rigidbody2D>();
    }

    // Called when this component becomes enabled
    void OnEnable()
    {
        // Subscribe to the jump input event
        inputManager.OnJump += HandleJumpInput;

        // Subscribe to the movement input event
        inputManager.OnMove += HandleMoveInput;
    }

    // Called when this component becomes disabled
    void OnDisable()
    {
        // Unsubscribe from the jump event to prevent errors or duplicate calls
        inputManager.OnJump -= HandleJumpInput;

        // Unsubscribe from the movement event
        inputManager.OnMove -= HandleMoveInput;
    }

    // Called when the InputManager signals a jump input
    void HandleJumpInput()
    {
        // Safety check: if Rigidbody2D is missing, do nothing
        if (_playerRb == null) return;

        // Only allow jumping if the player is on the ground
        if (_isOnGround)
            // Apply an instant upward force to simulate a jump
            _playerRb.AddForceY(jumpForce, ForceMode2D.Impulse);
    }

    // Called whenever movement input changes
    void HandleMoveInput(float value)
    {
        // Store the horizontal input value for use in FixedUpdate
        _horizontalInput = value;
    }

    // FixedUpdate is called at a fixed time step (used for physics)
    void FixedUpdate()
    {
        // Handle horizontal movement using physics
        HandleMovement();

        // Check whether the player is on the ground
        GroundCheck();
    }

    // Applies horizontal movement to the Rigidbody
    void HandleMovement()
    {
        // Safety check to avoid null reference errors
        if (_playerRb == null) return;

        // Set the Rigidbody’s horizontal velocity
        // Vertical velocity is preserved automatically
        _playerRb.linearVelocityX = moveSpeed * _horizontalInput;
    }

    // Checks if the player is standing on the ground
    void GroundCheck()
    {
        // Cast a ray downward from an offset position
        // If it hits the ground layer within distance, the player is grounded
        _isOnGround = Physics2D.Raycast((Vector2)transform.position + startPointOffset, Vector2.down, groundCheckDistance, groundLayer);
    }

    // Draws visual debug lines in the Scene view
    void OnDrawGizmos()
    {
        // Draws the ground-check ray
        // Green when grounded, red when in the air
        Debug.DrawLine((Vector2)transform.position + startPointOffset, (Vector2)transform.position + startPointOffset + Vector2.down * groundCheckDistance, _isOnGround ? Color.green : Color.red);
    }
}
