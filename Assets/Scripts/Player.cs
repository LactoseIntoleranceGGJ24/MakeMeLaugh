using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _maxSpeed = 5f;
<<<<<<< Updated upstream
    [SerializeField] private float _acceleration = 6f;
    [SerializeField] private float _deceleration = 5f;
    private float _currentMaxSpeed = 0f;
    private float _currentSpeed;
    private Vector3 _velocity;
    private void Update()
=======
    [SerializeField] private SpriteRenderer _sr;
    private float _currentSpeed;

    void Update()
>>>>>>> Stashed changes
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float targetSpeed = new Vector2(horizontalInput, verticalInput).magnitude * _maxSpeed;
        _currentSpeed = Mathf.MoveTowards(_currentSpeed, targetSpeed, Time.deltaTime * 2f);

<<<<<<< Updated upstream
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized * _currentSpeed;
        _velocity += movement * Time.deltaTime * _acceleration;
        _velocity = Vector3.ClampMagnitude(_velocity, _currentMaxSpeed);
        Debug.Log(_velocity.magnitude);
        this.transform.position += _velocity * Time.deltaTime;


        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) //slow player to halt if no input
        {
            _currentMaxSpeed -= Time.deltaTime * _deceleration;
        } else
        {
            _currentMaxSpeed = _maxSpeed;
        }

        if (_currentMaxSpeed > _maxSpeed)
        {
            _currentMaxSpeed = _maxSpeed;
        }
        if (_currentMaxSpeed <= 0)
        {
            _currentMaxSpeed = 0;
        }
=======
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * _currentSpeed;
        _rb.velocity = movement;

        _sr.flipX = horizontalInput > 0;
>>>>>>> Stashed changes
    }
}
