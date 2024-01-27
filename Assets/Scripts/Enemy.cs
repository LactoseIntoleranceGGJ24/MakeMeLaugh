using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _strength = 0.5f;
    [SerializeField] private float _moveSpeed = 0.5f;
    [SerializeField] private float _despawnDistance = 20f;
    [SerializeField] private SpriteRenderer _sr;
    private Transform _player;

    private float _knockbackDuration;
    private Vector2 _knockbackVelocity;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if(_knockbackDuration > 0)
        {
            transform.position += (Vector3)_knockbackVelocity * Time.deltaTime;
            _knockbackDuration -= Time.deltaTime;

            _sr.flipX = _knockbackVelocity.x > 0;
        } 
        else 
        {
            var newPosition = Vector2.MoveTowards(transform.position, _player.position, _moveSpeed * Time.deltaTime);

            _sr.flipX = newPosition.x > transform.position.x;
            transform.position = newPosition;

        }

        if((_player.transform.position - transform.position).magnitude > _despawnDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var dir = (Vector2)transform.position - (Vector2)collider.transform.position;
        
        if(collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(_strength);
            SetKnockback(dir.normalized * 0.4f, 0.2f);
        }
        
        SetKnockback(dir.normalized * 0.2f, 0.1f);
    }

    void OnTriggerStay2D(Collider2D collider)
    {   
        if(collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerHealth>().TakeDamageOverTime(_strength);
        }
    }

    void SetKnockback(Vector2 force, float duration)
    {
        if(_knockbackDuration > 0) {
            return;
        }

        _knockbackDuration = duration;
        _knockbackVelocity = force;
    }
}
