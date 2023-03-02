using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20.0f;
    public Rigidbody2D rb;
    void Start()
    {
        if (GameObject.Find("Bengt").transform.localScale.x < 0)
        {
            rb.velocity = Vector2.left * speed;
        }
//Tells the bullet to move right in according to the speed variable. 
        else 
        {
            rb.velocity = Vector2.right * speed;
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(20);
        }
        //Destroyes the bullet whenever something enters it's trigger.
        Destroy(gameObject);
    }
}