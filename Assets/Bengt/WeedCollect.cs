using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeedCollect : MonoBehaviour {
    public AudioSource _coinpickup;
    private short _mjölAntal;
    public GameObject mjol1;
    public GameObject mjol2;
    public GameObject mjol3;

    //Checks if the player has collided with a trigger collider with the tag "White".
    private void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.gameObject.CompareTag("White")) {
            _coinpickup.Play(); //Plays a sound whenever you hit the collider
            Destroy(collider2D.gameObject); //Destroyes the gameobject.
            _mjölAntal++; //Adds plus one to the _mjölantal variable. 
            print(_mjölAntal); 
             switch (_mjölAntal)
            {
                //Replaces the empty mjöl image with a full mjöl image when mjöl is collected.
                case 1: mjol1.SetActive(true); break;
                case 2: mjol2.SetActive(true); break;
                case 3: mjol3.SetActive(true); break;
            }
        }
    }
}           

