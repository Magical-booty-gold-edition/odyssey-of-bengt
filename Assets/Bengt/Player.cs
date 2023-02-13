using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class Player : MonoBehaviour{
    public float speed = 250.0f;
    public float jumpForce = 12.0f;
    public float SpringJump = 23.0f;
    public short Health = 3;

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
        if (Health <= 0)
        {
            Application.Quit();
        }
    }
    public void TakeDamage(short Damage)
    {
        Health -= Damage;
    }
    private void OnTriggerEnter2D(Collider2D collider2D){
       if (collider2D.gameObject.CompareTag("Spring")) {
           _body.AddForce(Vector2.up * SpringJump, ForceMode2D.Impulse);
        }
       if (collider2D.gameObject.CompareTag("DmgObject"))
        {
            TakeDamage(1);
        }
    }
}
