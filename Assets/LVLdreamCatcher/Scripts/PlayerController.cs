using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private float xPositionBound = 4f;
    public float speed = 10.0f;
    private PointSystem pointSystem;
    private float height = 0;

    public float jitterAmplitude = 0.2f; // Amplitude of the sinusoidal jitter
    public float jitterFrequency = 0.5f; // Frequency of the sinusoidal jitter


    // Start is called before the first frame update
    void Start()
    {
        pointSystem = GameObject.Find("Game Manager").GetComponent<PointSystem>();
        height = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        // Calculate the vertical jitter based on the sine function
        float verticalJitter = Mathf.Sin(2 * Mathf.PI * jitterFrequency * Time.time) * jitterAmplitude;

        // Check and handle position bounds for the x axis
        if (transform.position.x < -xPositionBound)
        {
            transform.position = new Vector2(-xPositionBound, height + verticalJitter);
        }
        else if (transform.position.x > xPositionBound)
        {
            transform.position = new Vector2(xPositionBound, height + verticalJitter);
        }
        else
        {
            // Move the object horizontally based on input
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * Time.deltaTime * horizontalInput * speed);

            // Apply the vertical jitter
            transform.position = new Vector2(transform.position.x, height + verticalJitter);
        }
    }

    //Player colides with spawn objects
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemie"))
        {
            pointSystem.AddLive(-1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Powerup"))
        {

            pointSystem.AddPoint(1);
            Destroy(other.gameObject);
        }
    }
}