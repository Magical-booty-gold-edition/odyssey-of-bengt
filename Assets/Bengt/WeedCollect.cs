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
            mjol1.SetActive(true);
            _mjölAntal++;
            if (_mjölAntal > 1)
            {
                mjol2.SetActive(true);
            }
            if (_mjölAntal > 2)
            {
                mjol3.SetActive(true);
            }
        }
    }
}
