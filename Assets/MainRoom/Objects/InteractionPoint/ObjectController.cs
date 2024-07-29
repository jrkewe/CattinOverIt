using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{

    private bool _enabled = false;
    private bool _isDisplaying = false;

    private Animator _animator;

    public GameObject _blur;
    [SerializeField] private CatController _player;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _blur = GameObject.FindWithTag("PauseBlur");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _enabled)
        {
            transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
            _enabled = false;
            _isDisplaying = true;

            // zoom in the sprite of the item
            Debug.Log("interaction");
            Debug.Log("popIn start");
            _animator.Play("popIn");
            Debug.Log("popIn done");
            // Activate blurry filter
            _blur.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.7f);

            // Freeze cat movements
            _player.canMove = false;
            
        }
        else if(Input.GetKeyDown(KeyCode.E) && _isDisplaying)
        {
            
            _isDisplaying = false;
            Debug.Log("popout start");
            _animator.Play("popOut");
            Debug.Log("popOut done");
            _player.canMove = true;
            _blur.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _enabled = true;
            Debug.Log("staying");
        }
        
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _enabled = false;
            Debug.Log("staying");
        }
    }

    public void resetPosition()
    {
        transform.position = Vector3.zero;
    }

}
