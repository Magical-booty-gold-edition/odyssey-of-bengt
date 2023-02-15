using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Springs : MonoBehaviour
{
    public Rigidbody2D _body;
    public float SpringJump = 20.0f;
    private void Start()
    {
        GameObject.Find("Bengt").GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _body.AddForce(Vector3.up * SpringJump);
        }
    }
}
