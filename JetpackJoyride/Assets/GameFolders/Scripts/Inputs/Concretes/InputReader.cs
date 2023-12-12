using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader
{
    PlayerInput _inputActions;

    private bool _forceUpButtonDown;
    public bool ForceUpButtonDown => _forceUpButtonDown;
    public InputReader()
    {
        _inputActions = new PlayerInput();
        _inputActions.Player.ForceUp.performed += context => _forceUpButtonDown = context.ReadValueAsButton();
        _inputActions.Enable();
    }


}
