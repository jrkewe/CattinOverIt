using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    public GameObject[] enemiesPrefabs;
    public GameObject[] powerupsPrefabs;
    private float xPositionSpawn = 4f;
    private float yPositionSpawn = 6f;

    //Spawn timing
    private float startEnemieDelay = 2.0f;
    private float startPowerupDelay = 5.0f;
    private float spawnEnemieInterval = 1.5f;
    private float spawnPowerupInterval = 3.5f;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemie", startEnemieDelay, spawnEnemieInterval);

        InvokeRepeating("SpawnRandomPowerup", startPowerupDelay, spawnPowerupInterval);
    }

    void SpawnRandomEnemie()
    {
        int enemie = Random.Range(0, enemiesPrefabs.Length);
        float randomPosition = Random.Range(-xPositionSpawn, xPositionSpawn);
        Vector3 spawnPosition = new Vector2(randomPosition, yPositionSpawn);
        Instantiate(enemiesPrefabs[enemie], spawnPosition, enemiesPrefabs[enemie].transform.rotation);
    }

    void SpawnRandomPowerup()
    {
        int powerupIndex = Random.Range(0, powerupsPrefabs.Length);
        float randomPosition = Random.Range(-xPositionSpawn, xPositionSpawn);
        Vector3 spawnPosition = new Vector2(randomPosition, yPositionSpawn);
        Instantiate(powerupsPrefabs[powerupIndex], spawnPosition, powerupsPrefabs[powerupIndex].transform.rotation);
    }

    public void StopInvoke() 
    {
        CancelInvoke();
    }

    public void StartInvoke(float enemieInterval, float powerupInterval) 
    {

        InvokeRepeating("SpawnRandomEnemie", startEnemieDelay, enemieInterval);

        InvokeRepeating("SpawnRandomPowerup", startPowerupDelay, powerupInterval);
        Debug.Log("enemie:"+ enemieInterval+ "powerup" + powerupInterval);
    }
}