using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _maxSpeed = 7f;
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private float _acceleration = 20f;
    [SerializeField] private float _deceleration = 7f;
    private float _currentMaxSpeed = 0f;
    private Vector3 _velocity;
    private Color _color = Color.white;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _sr.flipX = horizontalInput > 0;
        _color.r += 1 * Time.deltaTime;
        _color.b += 1 * Time.deltaTime;
        _color.g += 1 * Time.deltaTime;
        _sr.color = _color;

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized;
        _velocity += movement * Time.deltaTime * _acceleration;
        _velocity = Vector3.ClampMagnitude(_velocity, _currentMaxSpeed);
        //Debug.Log(_velocity.magnitude);
        this.transform.position += _velocity * Time.deltaTime;

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)     //slow player to halt if no input
        {
            _currentMaxSpeed -= Time.deltaTime * _deceleration;
        }
        else
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
    }

    public void ChangeColor(Color color)
    {
        _color = color;
    }
}
