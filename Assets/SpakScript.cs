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
    public GameObject Open_fac;
    public GameObject Closed_fac;

    public bool isP� = true;
    bool atLever = false;
    bool DoorOpen = false;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpakAv.GetComponent<SpriteRenderer>().sprite; 
    }

    private void OnTriggerEnter2D()
    {
        SpakText.SetActive(true);
        atLever = true;
    }

    private void OnTriggerExit2D()
    {
        SpakText.SetActive(false);
        atLever = false;
    }


    void FixedUpdate()
    { 
        if (atLever && Input.GetKeyDown(KeyCode.E))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = SpakP�.GetComponent<SpriteRenderer>().sprite;
                isP� = false;
                DoorOpen = true;
                Door.SetActive(false);
                Closed_fac.SetActive(false);
                Open_fac.SetActive(true);
            }
        
    }
}