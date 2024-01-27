using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _shootRate;

    private float _cooldown;

    void Start()
    {
        _cooldown = _shootRate;
    }

    void Update()
    {
        _cooldown -= Time.deltaTime;

        if (_cooldown <= 0)
        {
            _cooldown = _shootRate;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Vector2 direction = mousePosition - transform.position;

            GameObject bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetBulletDirection(direction);
        }
    }
}
