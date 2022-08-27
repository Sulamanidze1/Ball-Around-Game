using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject powerPrefab;
    [SerializeField] float powerSpawnStartTime = 4f;
    private int enemyNumberOnScene;
    private int roundNumber = 1;




    void Start()
    {
        SpawnEnemy(roundNumber);
        InvokeRepeating("SpawnPower", powerSpawnStartTime, Random.Range(8f, 17f));
    }


    void Update()
    {
        SpawnNewEnemies();
        

    }

    private Vector3 GenerateRandomPos()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-9f, 9f), 0, Random.Range(-9, 9));
        return spawnPosition;
    }

    private void SpawnEnemy(int enemNum)
    {
        for (int i = 0; i < enemNum; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPos(), enemyPrefab.transform.rotation);
        }
    }
    private void SpawnNewEnemies()
    {
        enemyNumberOnScene = FindObjectsOfType<Enemy>().Length;
        if (enemyNumberOnScene == 0)
        {
            roundNumber++;
            SpawnEnemy(roundNumber);
        }
    }

    private void SpawnPower()
    {
        Instantiate(powerPrefab, new Vector3(Random.Range(-9f,9f),0,Random.Range(-8f,8f)),powerPrefab.transform.rotation);
    }
}
