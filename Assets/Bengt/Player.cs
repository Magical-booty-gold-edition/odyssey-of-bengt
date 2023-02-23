using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Collections;

public class Player : MonoBehaviour{
    public float speed = 250.0f;
    public float jumpForce = 12.0f;
    public float Spring;

    public short Health = 3;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject NoHeart1;
    public GameObject NoHeart2;
    public GameObject NoHeart3;
    private bool IsJumping = false;
    private bool IsShooting = false;
    
    private Rigidbody2D _body;
    private Animator _anim;
    private BoxCollider2D _box;
    AudioSource _jumpsound;
    
    // Start is called before the first frame update
    void Start() {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _box = GetComponent<BoxCollider2D>();
        _jumpsound = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update() {
        print(IsJumping);
        float M = Input.GetAxis("Horizontal") * speed;
         Vector2 movement = new Vector2(M, _body.velocity.y);
        _body.velocity = movement;
        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - .1f);
        Vector2 corner2 = new Vector2(min.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2); 
        bool grounded = false; //changes to true if the player is on the ground and majes them 
        //able to jump.
        if (!Mathf.Approximately(M, 0)) {
            transform.localScale = new Vector3(Mathf.Sign(M), 1, 1); //when moving scale postive or negative 1 to face left or right.
        }                                                                  //detects if the player is on the ground or in the air.
            //detects if the player is grounded or not by using the hit variable. 
        if (hit != null) {
            grounded = true;
        }
        //Creates an jump impulse when the space key is pressed. 
        _body.gravityScale = grounded && M == 0 ? 0 : 1;
        if (grounded && Input.GetKeyDown(KeyCode.Space)) {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _jumpsound.Play();
       //     GetComponent<Animator>().SetBool("IsJumping", true);
       //     IsJumping = true;
        }
        //checks if the platform is moving or not.
        MovingPlatforms platform = null;
        if (hit != null) {
            platform = hit.GetComponent<MovingPlatforms>(); 
        }
        //either attach the player to platform or clear transform.parent.
        //Makes the player a child of the platform.
        if (platform != null) {
            transform.parent = platform.transform;
        } else {
            transform.parent = null;
        }
        _anim.SetFloat("speed", Mathf.Abs(M)); //speed greater than zero.
        Vector3 pScale = Vector3.one;
        if (platform != null) { //detects if the player is on the platform.
            pScale = platform.transform.localScale;
        }
        if (M != 0) {
            transform.localScale = new Vector3(
                Mathf.Sign(M) / pScale.x, 1 / pScale.y, 1);
        }
        if (Health == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            IsShooting = true;
        }
        else
        {
            IsShooting = false;
        }
        
    }
    public void TakeDamage(short Damage)
    {
        Health -= Damage;
    }
    private void OnTriggerEnter2D(Collider2D collider2D){
       if (collider2D.gameObject.CompareTag("DmgObject"))
        {
            TakeDamage(1);
            print(Health);
            switch (Health)
            {
                case 0: Heart1.SetActive(false); NoHeart1.SetActive(true); break;
                case 1: Heart2.SetActive(false); NoHeart2.SetActive(true); break;
                case 2: Heart3.SetActive(false); NoHeart3.SetActive(true); break;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spring"))
        {
            _body.velocity = Vector2.up * Spring;
        }
    }
}
