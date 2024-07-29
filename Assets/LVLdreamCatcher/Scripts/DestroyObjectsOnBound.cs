using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectsOnBound : MonoBehaviour
{
    private PointSystem pointSystem;

    private void Start()
    {
        pointSystem = GameObject.Find("Game Manager").GetComponent<PointSystem>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemie"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            pointSystem.AddPoint(-1);
        }
    }
}
