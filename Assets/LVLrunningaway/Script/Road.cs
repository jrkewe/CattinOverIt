using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Prompt :
 * Write a unity script that will move a sprite in a given direction.
 * At the beginning, a direction is chosen from a set of vector containing three directions:
 * down, down_left, down_right.
 * in the frame update, move the sprite in the chosen direction at a given speed.
 * the speed increase as the time pass (gravity effect).
 * Additionally, destroy the obstacle when it's outside the camera view.
 */
public class MoveRoadside : MonoBehaviour
{
    public float growthRate = 0.1f; // Amount by which the scale increase
    public float initialSpeed = 0.1f;
    public float gravityAcceleration = 9.8f;
    public Vector3 direction;
    private float speed;
    private Camera mainCamera;

    void Start()
    {
        // Initialize the speed
        speed = initialSpeed;

        // Get the main camera
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Increase speed over time to simulate gravity
        speed += gravityAcceleration * Time.deltaTime;

        // Move the sprite in the chosen direction
        transform.Translate(direction * speed * Time.deltaTime);

        // Scale the sprite making it appear closer
        Grow();

        // Check if the sprite is outside the camera view and destroy it if so
        if (!IsInView())
        {
            Destroy(gameObject);
        }
    }

    // Function to check if the sprite is within the camera view
    private bool IsInView()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        return viewportPosition.x >= 0 && viewportPosition.x <= 1 &&
               viewportPosition.y >= 0 && viewportPosition.y <= 1;
    }

    private void Grow()
    {
        // Calculate the growth increment based on the growth rate and the time passed since the last frame
        float growthAmount = growthRate * Time.deltaTime;

        // Increment the local scale of the GameObject
        transform.localScale += new Vector3(growthAmount, growthAmount, growthAmount);
    }

    // Method to set the direction
    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public void SetGravity(float gravity)
    {
        gravityAcceleration = gravity;
    }
    public void SetSpeed(float speed)
    {
        initialSpeed = speed;
    }
}
