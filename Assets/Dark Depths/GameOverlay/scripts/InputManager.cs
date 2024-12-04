using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public bool openAndCloseMenuInput { get; private set; }

    private PlayerInput _playerInput;
    private InputAction _menuOpenAndCloseAction;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        _playerInput = GetComponent<PlayerInput>();
        _menuOpenAndCloseAction = _playerInput.actions["MenuOpenAndClose"];
    }

    private void Update()
    {
        openAndCloseMenuInput = _menuOpenAndCloseAction.WasPressedThisFrame();
        Debug.Log(openAndCloseMenuInput);
    }
}
