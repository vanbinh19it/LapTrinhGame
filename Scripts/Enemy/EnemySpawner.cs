using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave{
        public string waveName;
        public List<EnemyGround> enemyGrounds;
        public int waveQuota; //the total of enemies to spawn this wave
        public float spawnInterval; //the interval at which to spawn enemies
        public int spawnCount; //the number of enemies of this type already spawned in this wave
    }

    [System.Serializable]
    public class EnemyGround
    {
        public GameObject enemyPrefabs;
        public string enemyName;
        public int enemyCount; //the number of enemies to spawn this wave
        public int spawnCount; //the number of enemies  already spawned in this wave
    }

    public List<Wave> waves; //a list of all the waves in the game
    public int currentWaveCount;
    Transform player;

    float spawnTimer;
    public int enemiesAlive;
    public int enemiesMaxAllowed;
    public bool maxEnemiesReached = false; //A flag indicating if the maximum number of enemies has been reach 
    float waveInterval;
    //spawn position
    public List<Transform> relativeSpawnPosition;

    private void Start() {
        player = FindObjectOfType<PlayerStats>().transform;
        CalculateWaveQuota();
        
    }
    private void Update() {
        if (currentWaveCount < (waves.Count)&&waves[currentWaveCount].spawnCount==0)
        {
            StartCoroutine(BeginNextWave());
        }

        spawnTimer += Time.deltaTime;
        if(spawnTimer > waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }

    IEnumerator BeginNextWave()
    {
        //wave for "waveInternal" seconds before starting next wave
        yield return new WaitForSeconds(waveInterval);
        if(currentWaveCount < waves.Count - 1)
        {
            currentWaveCount ++;
            CalculateWaveQuota();
        }
    }

    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGround in waves[currentWaveCount].enemyGrounds)
        {
            currentWaveQuota += enemyGround.enemyCount;
        }
        waves[currentWaveCount].waveQuota = currentWaveQuota;
        Debug.LogWarning(currentWaveQuota);
    }

    void SpawnEnemies()
    {
        if(waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota && !maxEnemiesReached)
        {
            //spawn each type off enemy until the quota filled
            foreach(var enemyGround in waves[currentWaveCount].enemyGrounds)
            {
                if(enemyGround.spawnCount < enemyGround.enemyCount)
                {
                    if(enemiesAlive >= enemiesMaxAllowed)
                    {
                        maxEnemiesReached=true;
                        return;
                    }

                    Instantiate(enemyGround.enemyPrefabs, player.position + relativeSpawnPosition[Random.Range(0, relativeSpawnPosition.Count)].position, Quaternion.identity);

                    enemyGround.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                    enemiesAlive++;
                }
            }
        }
        if(enemiesAlive < enemiesMaxAllowed)
        {
            maxEnemiesReached = false;
        }
    }
    public void OnEnemyKilled()
    {
        enemiesAlive--;
    }


}
