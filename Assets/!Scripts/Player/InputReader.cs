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

    public static Vector2 cursorPos = Vector2.zero;
    public UnityEvent<Vector2> cursorPostion;
    public void OnLook(InputAction.CallbackContext context)
    {
        cursorPos = context.ReadValue<Vector2>();
        cursorPostion?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnZoom(InputAction.CallbackContext context)
    {
    }
}
