using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatCollision : MonoBehaviour
{
    private RoomArrangement roomArrangementScript;

    private void Start()
    {
        roomArrangementScript = GameObject.Find("room_spritesheet_4").GetComponent<RoomArrangement>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bed"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("LVLdreamCatcher");
                roomArrangementScript.canChangeRoom = false;
            }
        }
        else if (other.CompareTag("Door"))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("LVLrunningaway");
                roomArrangementScript.canChangeRoom = true;
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Bed"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("LVLdreamCatcher");
                roomArrangementScript.canChangeRoom = false;
            }
        }
        else if (other.CompareTag("Door"))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("LVLrunningaway");
                roomArrangementScript.canChangeRoom = false;
            }
        }
    }
}
