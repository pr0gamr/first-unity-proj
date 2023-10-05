using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody objectToSpawn;
    public Rigidbody objectTwoSpawn;
    public Rigidbody objectThreeSpawn;
    public Transform barrelEnd;
    public Transform direction;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody bullet;
            bullet = Instantiate(objectToSpawn, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            bullet.GetComponent<Rigidbody>().AddForce(direction.forward * 7500);
            Debug.Log("shoot");
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Rigidbody bullet2;
            bullet2 = Instantiate(objectTwoSpawn, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            bullet2.GetComponent<Rigidbody>().AddForce(direction.forward * 5000);
            Debug.Log("shoot2");
        }
        if (Input.GetButtonDown("Fire3"))
        {
            Rigidbody bullet3;
            bullet3 = Instantiate(objectThreeSpawn, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            bullet3.GetComponent<Rigidbody>().AddForce(direction.forward * 10000);
            Debug.Log("shoot3");
        }
    }
}