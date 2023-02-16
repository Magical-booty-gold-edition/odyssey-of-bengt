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
    public GameObject SpakText;

    public bool isPå = true;
    bool atLever = false;
    bool DoorOpen = false;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpakAv.GetComponent<SpriteRenderer>().sprite; 
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        atLever = true;
    }

    void FixedUpdate()
    {
        if (atLever)
        {
            SpakText.SetActive(true);
        }
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