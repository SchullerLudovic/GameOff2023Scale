using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, InputActions.IPlayerActions
{
    public UnityEvent ShootEvent = new();

    private InputActions inputAction;

    public Vector2 Movement { get; private set; }

    private void Start()
    {
        inputAction = new();
        inputAction.Player.SetCallbacks(this);
        inputAction.Enable();
    }

    private void OnDestroy() => inputAction.Disable();

    public void OnMove(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        ShootEvent?.Invoke();
    }
}
