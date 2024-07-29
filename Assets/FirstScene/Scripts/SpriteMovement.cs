using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteMovement : MonoBehaviour
{
    // List of predefined positions as Vector3 coordinates
    private Vector3[] positions = new Vector3[]
    {
        //1row
        new Vector3(3.16f, -12.83f, 0),
        new Vector3(-3.13f, -12.83f, 0),
        //2row
        new Vector3(4.22f, -7.18f, 0),
        new Vector3(-4.14f, -7.18f, 0),
        //3row
        new Vector3(4.24f,-0.92f, 0),
        new Vector3(-4.2f, -0.92f, 0),
        //4row
        new Vector3(4.24f,4.76f, 0),
        new Vector3(-4.17f, 4.76f, 0),
        //5row
        new Vector3(0f, 12.31f, 0),
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