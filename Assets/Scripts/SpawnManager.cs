using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public GameObject powerupPrefabs;
    private float spawnRange = 9;

    public int enemyCount;
    public int waweNumber;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waweNumber);
        Instantiate(powerupPrefabs, RandomSpawnPos(), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; //tim cac Object co chu script ten la Enemy
        if (enemyCount == 0)
        {
            waweNumber++;
            SpawnEnemyWave(waweNumber);
            Instantiate(powerupPrefabs, RandomSpawnPos(), Quaternion.identity);
        }
    }
    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefabs, RandomSpawnPos(), enemyPrefabs.transform.rotation);
        }
    }
    private Vector3 RandomSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
