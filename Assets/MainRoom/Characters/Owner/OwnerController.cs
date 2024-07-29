using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerController : MonoBehaviour
{

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("idle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
