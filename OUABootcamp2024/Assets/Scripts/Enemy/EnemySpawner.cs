using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public GameObject enemyPrefab;
        public int enemyCount;
        public float spawnInterval;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;

    private int currentWaveIndex = 0;
    private float waveTimer;
    private float spawnTimer;
    private int enemiesSpawned;
    private bool waveInProgress = false;

    void Start()
    {
        waveTimer = timeBetweenWaves;
    }

    void Update()
    {
        if (currentWaveIndex < waves.Length)
        {
            if (!waveInProgress)
            {
                waveTimer -= Time.deltaTime;

                if (waveTimer <= 0f)
                {
                    waveInProgress = true;
                    waveTimer = timeBetweenWaves;
                }
            }
            else
            {
                SpawnWave();
            }
        }
    }

    void SpawnWave()
    {
        Wave currentWave = waves[currentWaveIndex];

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= currentWave.spawnInterval && enemiesSpawned < currentWave.enemyCount)
        {
            SpawnEnemy(currentWave.enemyPrefab);
            spawnTimer = 0f;
            enemiesSpawned++;
        }

        if (enemiesSpawned >= currentWave.enemyCount)
        {
            currentWaveIndex++;
            enemiesSpawned = 0;
            waveInProgress = false;
        }
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
    }
}
