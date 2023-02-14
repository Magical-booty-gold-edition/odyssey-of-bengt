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

    private void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.gameObject.CompareTag("White")) {
            _coinpickup.Play();
            Destroy(collider2D.gameObject);
            _mjölAntal++;
            print(_mjölAntal);
             switch (_mjölAntal)
            {
                case 1: mjol1.SetActive(true); break;
                case 2: mjol2.SetActive(true); break;
                case 3: mjol3.SetActive(true); break;
            }
        }
    }
}           

