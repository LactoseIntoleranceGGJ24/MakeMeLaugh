using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _defaultShootRate = 0.9f;
    [SerializeField] private int _defaultMaxHits;
    private float _shootRate;
    private int _maxHits;
    [SerializeField] private float _cooldown;
    private float _boostDuration;
    void Start()
    {
        _cooldown = _defaultShootRate;
        _shootRate = _defaultShootRate;
        _maxHits = _defaultMaxHits;
    }

    void Update()
    {

        _cooldown -= Time.deltaTime;
        _boostDuration -= Time.deltaTime;
        
        if (_shootRate >= _defaultShootRate)
        {
            _shootRate = _defaultShootRate;
            _maxHits = _defaultMaxHits;
        }
        if (_shootRate < 0.2f)
        {
            _shootRate = 0.2f;
        }
        if (_shootRate < 0.7f)
        {
            _maxHits = 50;
        }
        if (_boostDuration <=0)
        {
            _shootRate += 0.1f * Time.deltaTime;
            _boostDuration = 0; 
        }
        if (_cooldown <= 0)
        {
            _cooldown = _shootRate;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Vector2 direction = mousePosition - transform.position;

            GameObject bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetBulletDirection(direction, _maxHits);
        }
    }
    public void Boost (float firerateboost, float boostduration)
    {
        _shootRate -= firerateboost;
        _boostDuration += boostduration;
    }
}
