using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MGLController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // trigger the text bubble


    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (tag == "MGTrigger2")
        {
            // Wait for interaction button
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Switch scene
                SceneManager.LoadScene("LVLrunningaway");
            }
        } else if (tag == "MGTrigger")
        {
            // Wait for interaction button
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Switch scene
                SceneManager.LoadScene("LVLdreamCatcher");
                // SceneManager.LoadScene("LVLrunningaway");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Deactivate text bubble
    }
}
