using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerInputActions playerInputAct;

    public Action<Vector2, bool> onMove;
    public Action onJump;
    public Action onAttack;
    public Action onDodge;

    void Awake()
    {
        playerInputAct = new PlayerInputActions();
    }

    void OnEnable()
    {
        playerInputAct.Enable();
        playerInputAct.Player.Move.performed += OnMove;
        playerInputAct.Player.Move.canceled += OnMove;
        playerInputAct.Player.Jump.performed += OnJump;
        playerInputAct.Player.Attack.performed += OnAttack;
        playerInputAct.Player.Dodge.performed += OnDodge;
    }

    void OnDisable()
    {
        playerInputAct.Player.Move.performed -= OnMove;
        playerInputAct.Player.Move.canceled -= OnMove;
        playerInputAct.Player.Jump.performed -= OnJump;
        playerInputAct.Player.Attack.performed -= OnAttack;
        playerInputAct.Player.Dodge.performed -= OnDodge;
        playerInputAct.Disable();
    }

    void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        bool isPressed = !context.canceled;

        onMove(input, isPressed);
    }

    void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        onJump?.Invoke();
    }

    void OnAttack(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        onAttack?.Invoke();
    }

    void OnDodge(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        onDodge?.Invoke();
    }
}
