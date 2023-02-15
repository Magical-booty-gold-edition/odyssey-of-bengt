using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Springs : MonoBehaviour
{
    private Rigidbody2D _body;
    public float SpringJump = 20.0f;
    private void Start()
    {
        _body = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _body.AddForce(Vector3.up * SpringJump, ForceMode2D.Impulse);
        }
    }
}
