using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPController : MonoBehaviour
{

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
   

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _animator.SetBool("isEntered", true);
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _animator.SetBool("isEntered", false);
        }
        
    }
}
