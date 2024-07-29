using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteMover : MonoBehaviour
{
    // List of predefined positions as Vector3 coordinates
    private Vector3[] positions = new Vector3[]
    {
        new Vector3(11f, -23.8f, 0),
        new Vector3(-2f, -23.8f, 0),
        new Vector3(-12, -23.8f, 0),
        new Vector3(-10f, -12f, 0),
        new Vector3(10.5f, -12.5f, 0),
        new Vector3(12f, -1.5f, 0),
        new Vector3(5f, -1.5f, 0),
        new Vector3(-4f, -1.5f, 0),
        new Vector3(-12f, -1.5f, 0),
        new Vector3(10.5f, 8.5f, 0),
        new Vector3(-10f, 8.5f, 0),
        new Vector3(1, 20, 0)
    };

    // Current index in the list of positions
    private int currentIndex = 0;

    // Speed of movement
    public float moveSpeed = 5f;

    void Update()
    {
        // Check for space or right arrow key press to move forward
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveToNextPosition();
        }

        // Check for left arrow key press to move backward
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveToPreviousPosition();
        }

        // Smoothly move the sprite to the current target position
        transform.position = Vector3.MoveTowards(transform.position, positions[currentIndex], moveSpeed * Time.deltaTime);
    }

    void MoveToNextPosition()
    {
        if (currentIndex < positions.Length - 1)
        {
            currentIndex++;
        }
        else
        {
            // Load the next scene if the last position is reached
            LoadNextScene();
        }
    }

    void MoveToPreviousPosition()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("MainRoom");
    }
}