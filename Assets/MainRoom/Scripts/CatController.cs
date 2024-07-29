using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{

    private SpriteRenderer _renderer;
    private Rigidbody2D _body;
    private Animator _animator;

    private bool canJump = false;

    public bool canMove = true;

    public int crtLevel = 0;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 jumpHeight = new Vector2(0, 0.01f);

    [SerializeField] private GameObject _question;
    [SerializeField] private GameObject _exclamation;

    [SerializeField] private GameObject[] _botColliders;

    [SerializeField] private GameObject[] _topColliders;

    [SerializeField] private GameObject[] _roomColliders;

    [SerializeField] private GameObject[] _jumpPoints;

    [SerializeField] private GameObject[] _botJumpPoints;

    [SerializeField] Transform arrivalTransform;

    [SerializeField] private GameObject _textBox_1;

    [SerializeField] private GameObject _textBox_2;


    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(!canMove) 
        { 
            // Reset any input
            _animator.SetFloat("hor_move", 0);
            _animator.SetFloat("ver_move", 0);
            return;
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("hor_move", Mathf.Abs(h));
        _animator.SetFloat("ver_move", v);


        gameObject.transform.position = new Vector2 (transform.position.x + (h * moveSpeed), 
        transform.position.y + (v * moveSpeed));

        // flip the sprite when changing direction
        if(h == -1)
        {
            _renderer.flipX = false;
        }
        else if(h == 1)
        {
            _renderer.flipX = true;
        }

        // Jump
        if(Input.GetKey(KeyCode.Space) && canJump)
        {
            deactivateAllColliders();

            canMove = false;
            var posDelta = transform.position.x - arrivalTransform.position.x;
            Debug.Log(posDelta);
            if(crtLevel == 0){
                if(posDelta < 0)
                {
                    // Animate to the right
                    if(_renderer.flipX){
                        _renderer.flipX = false;
                    }
                }else
                {
                    // Animate to the left
                    if(!_renderer.flipX)
                    {
                        _renderer.flipX = true;
                    }
                }
            }else if(crtLevel == 1)
            {
                if(posDelta < 0)
                {
                    _renderer.flipX = true;
                }
            }

            if(crtLevel == 0)
            {
                // Play jump animation
                _animator.Play("Jump");
            }else if(crtLevel == 1)
            {
                _animator.Play("botJump");
            }

        }

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        // Pop the question mark when approaching a POI
        if(collider.tag == "Interactions")
        {
            _question.SetActive(true);
        }
        // Detect JumpPoints
        if(collider.tag == "JumpPoint")
        {
            canJump = true;
            _exclamation.SetActive(true);
            arrivalTransform = collider.transform;
        }
        if(collider.tag == "MGTrigger")
        {
            // trigger textbox
            _textBox_1.SetActive(true);
            
        }
        if(collider.tag == "MGTrigger2")
        {
            // trigger textbox
            _textBox_2.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        // Hide the question mark when exiting a POI
        if(other.tag == "Interactions")
        {
            _question.SetActive(false);
        }
        // Detect JumpPoints
        if(other.tag == "JumpPoint")
        {
            canJump = false;
            _exclamation.SetActive(false);
        }
        if(other.tag == "MGTrigger")
        {
            // trigger textbox out
            _textBox_1.SetActive(false);
        }
        if(other.tag == "MGTrigger2")
        {
            // trigger textbox
            _textBox_2.SetActive(false);
        }
    }

    public void Unlock()
    {
        canMove = true;
        _exclamation.SetActive(false);
        Debug.Log("unlocked");

    }

    public void TeleportCat()
    {
        transform.position = arrivalTransform.position;
    }


    // ANIMATION CONTROLLED : Activate colliders according to level of navigation
    private void updateNavLvl(int nextLvl)
    {
        if(nextLvl == 0)
        {
            crtLevel = 0;
            // Activate bot colliders
            foreach (var collider in _botColliders)
            {
                collider.SetActive(true);
            }

            // Activate room colliders
            foreach (var collider in _roomColliders)
            {
                collider.SetActive(true);
            }

            // deactivate bot jumpPoints
            foreach (var point in _botJumpPoints)
            {
                point.SetActive(false);
            }
            // activate top jump points
            foreach (var point in _jumpPoints)
            {
                point.SetActive(true);
            }

        }else if(nextLvl == 1)
        {
            crtLevel = 1;
            // Activate top colliders
            foreach (var collider in _topColliders)
            {
                collider.SetActive(true);
            }
            // deactivate top jumpPoints
            foreach (var point in _jumpPoints)
            {
                point.SetActive(false);
            }
            // activate bot jumpPoints
            foreach (var point in _botJumpPoints)
            {
                point.SetActive(true);
            }
        }
    }

    private void deactivateAllColliders()
    {
        // Deactivate all colliders
        foreach (var collider in _botColliders)
        {
            collider.SetActive(false);
        }
        foreach (var collider in _topColliders)
        {
            collider.SetActive(false);
        }
        foreach (var collider in _roomColliders)
        {
            collider.SetActive(false);
        }
    }

}
