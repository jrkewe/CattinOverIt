using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsCat : MonoBehaviour
{
    public GameObject cat;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cat.transform.position.x, cat.transform.position.y, transform.position.z);

    }
}
