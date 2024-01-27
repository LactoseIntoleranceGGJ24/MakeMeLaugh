using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnRadiusMin;
    [SerializeField] private float spawnRadiusMax;
    private float cooldown;

    void Start()
    {
        cooldown = spawnTime;
    }

    void Update()
    {
        var posY = Random.Range(0f, 0.1f);

        if (cooldown <= 0)
        {
            float angle = Random.Range(0f, 1f) * Mathf.PI * 2f;
            Vector2 pos = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * Random.Range(spawnRadiusMin, spawnRadiusMax);
            Instantiate(_enemy, pos + (Vector2)transform.position, Quaternion.identity);
            cooldown = spawnTime;
        }

        cooldown -= Time.deltaTime;
    }
}
