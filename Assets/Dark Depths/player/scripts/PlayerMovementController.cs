using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _movementDirection;
    
    [SerializeField] public float speed = 250f;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        SetPlayerVel();
    }
    
    private void SetPlayerVel()
    {
        _rb.velocity = _movementDirection * (speed * Time.fixedDeltaTime);
    }

    public void OnMove(InputValue movementValue)
    {
        _movementDirection = movementValue.Get<Vector2>();
    }
}
