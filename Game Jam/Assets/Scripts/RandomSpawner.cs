using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class RandomSpawner : MonoBehaviour
{
    [Header("Spawn")]
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    [Header("Configurations")]
    public float spawnTime;
    public static int enemyNumber;
    public float difficulty = 10;
    void Start()
    {
        
    }

    void Update()
    {
        EnemySpawn(); 
    }

    void EnemySpawn()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        if (enemyNumber < 10)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
            enemyNumber++;
        }
        yield return new WaitForSeconds(spawnTime);
    }
}
