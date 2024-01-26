using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float maxSpeed = 5f;
    private float currentSpeed;

    private void Update()
    {
        // Get input axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float targetSpeed = new Vector2(horizontalInput, verticalInput).magnitude * maxSpeed;
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, Time.deltaTime * 2f);

        // Move the player
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * currentSpeed;
        rb.velocity = movement;
    }
}
