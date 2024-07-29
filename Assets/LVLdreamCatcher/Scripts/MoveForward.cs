using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -speed * Time.deltaTime,0);
        transform.Rotate(new Vector3(0, 0,  rotationSpeed));
    }



}