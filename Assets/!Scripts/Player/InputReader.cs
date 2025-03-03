using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    [HideInInspector] public InputSystem_Actions playerInput;

    private void OnEnable()
    {
        playerInput = new InputSystem_Actions();
        playerInput.Player.SetCallbacks(this);

        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }

    public UnityEvent<Vector3> onMove;
    public void OnMove(InputAction.CallbackContext context)
    {
        onMove?.Invoke(context.ReadValue<Vector2>());
    }
}
