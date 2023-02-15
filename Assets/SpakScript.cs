using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpakScript : MonoBehaviour
{
    [SerializeField]
    GameObject SpakP�;

    [SerializeField]
    GameObject SpakAv;

    public bool isP� = true;
    bool atLever = true;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpakAv.GetComponent<SpriteRenderer>().sprite; 
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && atLever)  
        { 
            gameObject.GetComponent<SpriteRenderer>().sprite = SpakP�.GetComponent<SpriteRenderer>().sprite;
            isP� = false;
        }
    }

    void onTriggerExit2D()
    {
        atLever = false;
    }
    
}