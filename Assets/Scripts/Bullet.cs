using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    private int _maxHits;
    public float speed = 1f;         // Movement speed
    private Vector2 _bulletDirection;

    private float _time;


    void Start()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector2 direction = mousePosition - transform.position;
        direction.Normalize();

        _bulletDirection = direction;
        _rb.angularVelocity = Random.Range(-2000, 2000);
    }

    private void Update()
    {
        _rb.velocity = _bulletDirection * speed;

        _time += Time.deltaTime;
        if (_time > 5f)
        {
            Destroy(gameObject);
        }
        if (_maxHits == 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetBulletDirection(Vector2 dir, int maxHits)
    {
        _bulletDirection = dir;
        _maxHits = maxHits;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            _maxHits -= 1;
            //Enemy eScript = collider.gameObject.GetComponent<Enemy>();
            //eScript.Die();
            //Destroy(collider.gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            _maxHits -= 1;
        }
    }
}
