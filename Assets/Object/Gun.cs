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
    bool cooldown = false;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
            gunis.SetActive(true);
            cool_downie(0.5f);
        }
        else if (!cooldown)
        {
            gunis.SetActive(false);
        }
    }
    void Shoot()
    {
        //shooting logic
        Lastbulletmade = Instantiate(BulletPrefab, SpawnPos.position, SpawnPos.rotation);
    }
    
    void end_cooldown()
    {
        cooldown = false;
    }
    
    void cool_downie(float duration)
    {
        cooldown = true;
        Invoke("end_cooldown", duration);
    }
}
