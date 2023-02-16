using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpakScript : MonoBehaviour
{
    [SerializeField]
    GameObject SpakP�;

    [SerializeField]
    GameObject SpakAv;

    public GameObject Door;
    public GameObject SpakText;

    public bool isP� = true;
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
            gameObject.GetComponent<SpriteRenderer>().sprite = SpakP�.GetComponent<SpriteRenderer>().sprite;
            isP� = false;
            DoorOpen = true;
            Door.SetActive(false);
        }
    }

    void onTriggerExit2D()
    {
        atLever = false;
    }
    
}