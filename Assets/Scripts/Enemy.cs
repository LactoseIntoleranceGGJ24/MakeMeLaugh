using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _strength = 0.5f;
    [SerializeField] private float _moveSpeed = 0.5f;
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
        } 
        else 
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.position, _moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(_strength);

            var dir = (Vector2)transform.position - (Vector2)_player.position;
            SetKnockback(dir.normalized * 0.2f, 0.1f);
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
