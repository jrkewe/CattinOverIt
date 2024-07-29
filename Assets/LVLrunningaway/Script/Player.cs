using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * Prompt : write a unity csharp script that will move left and right the player if the left/right arrow are pressed or if the A or D key are pressed or if the display is touched on the left/right of the current position of the sprite.  here is what I have aldready : using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 * 
 */
public class Player : MonoBehaviour
{
    public float speed = 7.0f;
    public float leftBoundary = -5.0f;
    public float rightBoundary = 5.0f;
    private float currentTime;
    private MainManagerLVLrunningawayScene mainManagerLVLrunningawaySceneScript;
    private DataPersistanceManager dataPersistanceManagerScript;
    private Instantiation instantiationScript;

    void Start()
    {

        mainManagerLVLrunningawaySceneScript = GameObject.Find("Main Manager LVLrunningaway").GetComponent<MainManagerLVLrunningawayScene>();

        // Ensure the player has a Rigidbody2D component
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0; // Ensure the player is not affected by gravity
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime>90f)
        {
            GameOverWin();
        }
        HandleMovement();
    }

    void HandleMovement()
    {
        float move = 0f;

        // Keyboard input
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            move = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            move = 1f;
        }

        // Touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                if (touchPosition.x < transform.position.x)
                {
                    move = -1f;
                }
                else if (touchPosition.x > transform.position.x)
                {
                    move = 1f;
                }
            }
        }

        // Calculate new position
        Vector3 newPosition = transform.position + Vector3.right * move * speed * Time.deltaTime;

        // Clamp the new position within the boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, leftBoundary, rightBoundary);

        // Apply the clamped position
        transform.position = newPosition;
    }

    // Handle collision with obstacles
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameOverLoose();
        }
    }

    void GameOverWin()
    {
        // Implement your game over logic here
        Debug.Log("You won!");
        // For example, you can stop the game
        Time.timeScale = 0;
        // Or you can load a game over scene
        // SceneManager.LoadScene("GameOver");
        instantiationScript = GameObject.Find("Game Manager").GetComponent<Instantiation>();

        dataPersistanceManagerScript = GameObject.Find("Data Persistance Manager").GetComponent<DataPersistanceManager>();
        dataPersistanceManagerScript.roomChangementRunningAway = true;
        mainManagerLVLrunningawaySceneScript.Menu();
    }

    void GameOverLoose()
    {
        // Implement your game over logic here
        Debug.Log("You lost. Game Over!");
        // For example, you can stop the game
        Time.timeScale = 0;
        // Or you can load a game over scene
        // SceneManager.LoadScene("GameOver");

        mainManagerLVLrunningawaySceneScript.Menu();
    }
}
