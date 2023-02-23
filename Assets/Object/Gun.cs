using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform SpawnPos;
    public GameObject BulletPrefab;
    public GameObject gunis;
    GameObject Lastbulletmade;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
            gunis.SetActive(true);
        }
        else
        {
            gunis.SetActive(false);
        }
    }
    void Shoot()
    {
        //shooting logic
        Lastbulletmade = Instantiate(BulletPrefab, SpawnPos.position, SpawnPos.rotation);
    }
}
