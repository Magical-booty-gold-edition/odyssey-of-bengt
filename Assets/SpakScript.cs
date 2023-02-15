using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpakScript : MonoBehaviour
{
    [SerializeField]
    GameObject SpakPå;

    [SerializeField]
    GameObject SpakAv;

    public GameObject Door;

    public bool isPå = true;
    bool atLever = true;
    bool DoorOpen = false;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpakAv.GetComponent<SpriteRenderer>().sprite; 
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && atLever)  
        { 
            gameObject.GetComponent<SpriteRenderer>().sprite = SpakPå.GetComponent<SpriteRenderer>().sprite;
            isPå = false;
            DoorOpen = true;
            Door.SetActive(false);
        }
    }

    void onTriggerExit2D()
    {
        atLever = false;
    }
    
}