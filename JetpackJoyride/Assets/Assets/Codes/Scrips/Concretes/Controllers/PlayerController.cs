using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput _input;
    Rigidbody2D _rigidbody2D;

    private bool _isUpPresed;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = new PlayerInput();
    }
    private void Update()
    {
        if (_input.UpKeyDown)
        {
            _isUpPresed = true;
        }
        else
        {
            _isUpPresed = false;
        }
    }
    private void FixedUpdate()
    {
        if (_isUpPresed)
        {
            _rigidbody2D.AddForce(Vector2.up * 1, ForceMode2D.Impulse);
        }
    }

}
