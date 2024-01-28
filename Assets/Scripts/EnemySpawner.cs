using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnRadiusMin;
    [SerializeField] private float spawnRadiusMax;
    [SerializeField] private GameObject reviews;
    AudioSource gull;
    private float cooldown;
    private float[] spawnTimes = {6f, 4f, 0.2f , 0.2f, 0.1f, 0.1f, 0.9f, 0.8f, 0.7f};
    private int j = 0;
    void Start()
    {
        cooldown = spawnTime;
        gull = GetComponent<AudioSource>();
    }

    void Update()
    {
        var posY = Random.Range(0f, 0.1f);

        if (cooldown <= 0)
        {
            float angle = Random.Range(0f, 1f) * Mathf.PI * 2f;
            Vector2 pos = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * Random.Range(spawnRadiusMin, spawnRadiusMax);
            Instantiate(_enemy, pos + (Vector2)transform.position, Quaternion.identity);
            cooldown = spawnTimes[j];
        }

        cooldown -= Time.deltaTime;
    }

    public void IncreaseSpawnRate()
    {
        if (j == 2)
        {
            Gull();
            reviews.GetComponent<ReviewScript>().WarmupOver();
        }
        if (j >= spawnTimes.Length)
        {
            j = spawnTimes.Length;
        } else
        {
            j++;
            Debug.Log("spawn rate increased to level " + j);
        }
        
    }
    public void Gull()
    {
        gull.Play();
        gull.loop = true;
        Debug.Log("Gull.");
    }
}
