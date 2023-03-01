using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public Vector3 finishPos = Vector3.zero;
    public float speed = 1.5f;
    public Vector3 _StartPos;
    private float _trackPercent = 0;
    private int _direction = 1;

    public void Start()
    {
        _StartPos = transform.position;
    }
    public void TakeDamage (int damgage)
    {
        health -= damgage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    public void Update()
    {
        _trackPercent += _direction * speed * Time.deltaTime;
        float x = (finishPos.x - _StartPos.x) * _trackPercent + _StartPos.x;
        float y = (finishPos.y - _StartPos.y) * _trackPercent + _StartPos.y;
        transform.position = new Vector3(x, y, _StartPos.z);

        if ((_direction == 1 && _trackPercent > .9f) || (_direction == -1
                && _trackPercent < .1f))
        {
            _direction *= -1;
        }
        if (!Mathf.Approximately(speed, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(speed), 1, 1); //when moving scale postive or negative 1 to face left or right.
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, finishPos);
    }
}
