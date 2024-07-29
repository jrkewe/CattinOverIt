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
public class ObstacleSpawner : MonoBehaviour
{
    private float difficulty = 0f;

    // Public variables for obstacle prefab and lambda N
    public GameObject obstacleA;
    public GameObject obstacleB;
    public GameObject obstacleC;
    public GameObject obstacleD;
    public GameObject obstacleE;
    public GameObject obstacleF;
    public GameObject obstacleG;
    public GameObject obstacleH;

    // List of possible directions
    private List<Vector3> directions = new List<Vector3>
    {
        Vector3.down,
        new Vector3(-0.3f, -1, 0).normalized, // Down-Left
        new Vector3(0.3f, -1, 0).normalized,   // Down-Right
        new Vector3(-0.5f, -1, 0).normalized, // Down-Left
        new Vector3(0.5f, -1, 0).normalized,   // Down-Right
    };

    // Start is called before the first frame update
    void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnObstacles());
    }

    //////////////////////////////////////////////////////Difficulty
    public void SetDifficulty(float difficultyValue) 
    {
        difficulty = difficultyValue;
    }
    //////////////////////////////////////////////////////Difficulty

    // Coroutine to spawn obstacles
    IEnumerator SpawnObstacles()
    {

        List<GameObject> obstaclePool = new List<GameObject> { obstacleA, obstacleB, obstacleC, obstacleD, obstacleE, obstacleF, obstacleG, obstacleH };

        while (true)
        {
            float elapsedTime = Time.time; // know for how long the game has been running.

            //--------------------------------------------------------------------------------------- Obstacle Acceleration

            // Calculate the acceleration using the currently elapsed time and a random component
            float currentObstacleAcceleration = (float)(2 * Math.Exp((Math.Log(2) * (elapsedTime / 40))));
            float jitterAcceleration = UnityEngine.Random.Range(-0.2f, 0.2f);
            // Apply the jitter to the Acceleration time
            currentObstacleAcceleration = currentObstacleAcceleration * (1 + jitterAcceleration);

            //--------------------------------------------------------------------------------------- Obstacle configuration 
            int numberOfObstacles = 1;

            if (elapsedTime > 15)
            {
                float randomValue = UnityEngine.Random.value;

                if (randomValue <= 0.2f)
                {
                    numberOfObstacles = 3;
                }
                else if (randomValue <= 0.4f)
                {
                    numberOfObstacles = 2;
                }
                else
                {
                    numberOfObstacles = 1;
                }
            }

            // Shuffle directions
            List<Vector3> shuffledDirections = new List<Vector3>(directions);
            for (int i = 0; i < shuffledDirections.Count; i++)
            {
                Vector3 temp = shuffledDirections[i];
                int randomIndex = UnityEngine.Random.Range(i, shuffledDirections.Count);
                shuffledDirections[i] = shuffledDirections[randomIndex];
                shuffledDirections[randomIndex] = temp;
            }

            //--------------------------------------------------------------------------------------- SPAWN RATE
            // Calculate the next spawn time using the currently elapsed time and a random component
            float spawnTime = (float)(1 * Math.Exp((elapsedTime / 120)));

            // Generate a random jitter between -0.2 and +0.2
            float jitter = UnityEngine.Random.Range(-0.2f, 0.2f);

            // Apply the jitter to the spawn time
            spawnTime = spawnTime * (1 + jitter);


            yield return new WaitForSeconds(spawnTime );

            for (int i = 0; i < numberOfObstacles; i++)
            {
                // Choose a unique direction from the shuffled list
                Vector3 chosenDirection = shuffledDirections[i % shuffledDirections.Count];

                int obstacleDesignIndex = UnityEngine.Random.Range(0, 8);
                // Spawn the obstacle at the spawner's position
                GameObject obstacle = Instantiate(obstaclePool[obstacleDesignIndex], transform.position, Quaternion.identity);

                // Set the direction for the MoveSprite component
                MoveSprite moveSprite = obstacle.GetComponent<MoveSprite>();
                moveSprite.SetDirection(chosenDirection);
                moveSprite.SetGravity(currentObstacleAcceleration);
            }
        }
    }
}
