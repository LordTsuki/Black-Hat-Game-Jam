using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class RandonSpawner : MonoBehaviour
{
    [Header("Spawn")]
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    [Header("Configurations")]
    public float spawnTime;
    private int enemyNumber;
    private int difficulty;
    void Start()
    {
        
    }

    void Update()
    {
        if(enemyNumber < difficulty)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
        }    
    }

    void EnemySpawn()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        if (enemyNumber < difficulty)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
        }
        difficulty += GameController.instance.score / 5;
        yield return new WaitForSeconds(spawnTime);
    }
}
