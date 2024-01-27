using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private SpriteRenderer _sr;
    private float _currentSpeed;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float targetSpeed = new Vector2(horizontalInput, verticalInput).magnitude * _maxSpeed;
        _currentSpeed = Mathf.MoveTowards(_currentSpeed, targetSpeed, Time.deltaTime * 2f);

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * _currentSpeed;
        _rb.velocity = movement;

        _sr.flipX = horizontalInput > 0;
    }
}
