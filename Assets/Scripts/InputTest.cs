using UnityEngine;
using UnityEngine.InputSystem;

public class Inputtest : MonoBehaviour
{
    private PlayerInputActions _testActions;

    void Awake()
    {
        _testActions = new PlayerInputActions(); //created an object
        _testActions.Enable(); //turns it on to listen to key inputs
    }

    void OnEnable()
    {
        _testActions.Player.Jump.performed += Jump;
    }

    void OnDisable()
    {
        _testActions.Player.Jump.performed -= Jump;
    }

    void Jump(InputAction.CallbackContext ctx)
    {
        Debug.Log("Jump");
    }
}