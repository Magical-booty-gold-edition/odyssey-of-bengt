using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Springs : MonoBehaviour
{
    private Rigidbody2D _body;
    public float SpringJump = 20.0f;
    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Spring"))
        {
            _body.AddForce(Vector2.up * SpringJump, ForceMode2D.Impulse);
        }
    }
}
