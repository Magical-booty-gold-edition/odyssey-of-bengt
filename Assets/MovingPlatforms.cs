using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour {
    public Vector3 finishPos = Vector3.zero;
    public float speed = 0.5f;
    public Vector3 _StartPos;
    private float _trackPercent = 0;
    private int _direction = 1;

    // Start is called before the first frame update
    void Start() {
        _StartPos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        _trackPercent += _direction * speed * Time.deltaTime;
        float x = (finishPos.x - _StartPos.x) * _trackPercent + _StartPos.x;
        float y = (finishPos.y - _StartPos.y) * _trackPercent + _StartPos.y;
        transform.position = new Vector3(x, y, _StartPos.z);

        if ((_direction == 1 && _trackPercent > .9f) || (_direction == -1
                && _trackPercent < .1f)) {
            _direction *= -1;
        }
    }
    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, finishPos);
    }
}
