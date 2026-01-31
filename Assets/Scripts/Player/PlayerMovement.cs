using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private InteractionController interactions;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        interactions = GetComponent<InteractionController>();
    }

    private void FixedUpdate()
    {
        if (!interactions.hiding)
            _rigidbody.linearVelocity = _movementInput * _speed;
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}
