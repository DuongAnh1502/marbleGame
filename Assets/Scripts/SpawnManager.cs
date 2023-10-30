using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public GameObject powerUpPrefabs;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefabs, GenerateSpawnPosition(), powerUpPrefabs.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            SpawnEnemyWave(++waveNumber);
            Instantiate(powerUpPrefabs, GenerateSpawnPosition(), powerUpPrefabs.transform.rotation);
        }
    }
    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX,0,spawnPosZ);
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0;i< enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefabs, GenerateSpawnPosition(), enemyPrefabs.transform.rotation);
        }
    }
}
