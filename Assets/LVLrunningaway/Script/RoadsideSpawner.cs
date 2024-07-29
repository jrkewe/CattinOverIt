using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * 
 * 
 * write a spawner for unity,
 * the spawner create a new obstacle
 * the obstacle is public and can be changed.
 * 
 */
public class RoadSideSpawner : MonoBehaviour
{
    // Public variables for obstacle prefab and lambda N
    public GameObject roadside1;
    public GameObject roadside2;
    public GameObject roadside3;
    public GameObject roadside4;
    public GameObject roadside5;
    public GameObject roadside6;

    // List of possible directions
    private List<Vector3> directions = new List<Vector3>
    {
        Vector3.down,
        new Vector3(-0.5f, -1, 0).normalized, // Down-Left
        new Vector3(0.5f, -1, 0).normalized   // Down-Right
    };

    // Start is called before the first frame update
    void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnObstacles());
    }

    // Coroutine to spawn obstacles
    IEnumerator SpawnObstacles()
    {
        List<GameObject> roadside = new List<GameObject> { roadside1, roadside2, roadside3, roadside4, roadside5, roadside6 };
        while (true)
        {
            float elapsedTime = Time.time; // know for how long the game have been running.
            //--------------------------------------------------------------------------------------- Initial speed
            float innitialSpeed = (float)(0.5 * Math.Exp(-(Math.Log(2) * (elapsedTime / 200))));

            //--------------------------------------------------------------------------------------- Obstacle Acceleration

            // Calculate the acceleration using the currently elapsed time and a random component
            float currentObstacleAcceleration = (float)(1 * Math.Exp(-(Math.Log(2) * (elapsedTime / 30))));
            //--------------------------------------------------------------------------------------- Obstacle configuration 

            // Spawn the obstacle at the spawner's position
            GameObject obstacleH = Instantiate(roadside[UnityEngine.Random.Range(0, 6)], transform.position, Quaternion.identity);

            // Set the direction for the MoveSprite component
            MoveRoadside moveSpriteH = obstacleH.GetComponent<MoveRoadside>();
            moveSpriteH.SetDirection(directions[2]);
            Vector3 initialPosition = new Vector3(4.5f, 4.5f, 0);
            moveSpriteH.SetPosition(initialPosition);
            moveSpriteH.SetGravity(currentObstacleAcceleration);
            moveSpriteH.SetSpeed(innitialSpeed);

            // Spawn the obstacle at the spawner's position
            GameObject obstacleI = Instantiate(roadside[UnityEngine.Random.Range(0, 6)], transform.position, Quaternion.identity);

            // Set the direction for the MoveSprite component
            MoveRoadside moveSpriteI = obstacleI.GetComponent<MoveRoadside>();
            moveSpriteI.SetDirection(directions[1]);
            initialPosition = new Vector3(-4.5f, 4.5f, 0);
            moveSpriteI.SetPosition(initialPosition);
            moveSpriteI.SetGravity(currentObstacleAcceleration);
            moveSpriteI.SetSpeed(innitialSpeed);

            //--------------------------------------------------------------------------------------- SPAWN RATE
            // Calculate the next spawn time using the currently elapsed time and a random component
            float spawnTime = (float)(2 * Math.Exp(-(Math.Log(2) * (elapsedTime / 200))));

            yield return new WaitForSeconds((spawnTime));
        }
    }
}
