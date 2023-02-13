using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpakScript : MonoBehaviour
{
    [SerializeField]
    GameObject SpakAv;

    [SerializeField]
    GameObject SpakP�;

    public bool isP� = false;
    bool atLever = false;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpakAv.GetComponent<SpriteRenderer>().sprite; 
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && atLever)  
        { 
            gameObject.GetComponent<SpriteRenderer>().sprite = SpakP�.GetComponent<SpriteRenderer>().sprite; 
        }
    }

    void onTriggerExit2D()
    {
        atLever = false;
    }
    
}