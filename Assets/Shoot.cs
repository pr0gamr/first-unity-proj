using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody objectToSpawn;
    public Transform barrelEnd;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody bullet;
            bullet = Instantiate(objectToSpawn, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            bullet.GetComponent<Rigidbody>().AddForce(barrelEnd.forward * 2250);
            Debug.Log("shoot");
        }
    }
}