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
    float LoadOut = 1;
    float m_FieldOfView;
    float Sensitivity;

    void start()
    {
        m_FieldOfView = 60.0f;
    }

    void Update()
    {
        m_FieldOfView = 60.0f;
        Sensitivity = 2.8f;
        if (LoadOut == 1)
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
        }
        else if (LoadOut == 2)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Rigidbody bullet3;
                bullet3 = Instantiate(objectThreeSpawn, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
                bullet3.GetComponent<Rigidbody>().AddForce(direction.forward * 50000);
                Debug.Log("shoot3");
            }
        }
        else if (LoadOut == 3)
        {
            if(Input.GetButtonDown("Fire1"))
            {

            }
            if (Input.GetButton("Fire2"))
            {
                m_FieldOfView = 10f;
            }
        }
        if (Input.GetButtonDown("Fire3"))
        {
            if (LoadOut == 1)
            {
                LoadOut = 2;
            }
            else if (LoadOut == 2)
            {
                LoadOut = 3;
            }
            else if (LoadOut == 3)
            {
                LoadOut = 1;
                Sensitivity = 1f;
            }
            Debug.Log(LoadOut);
        }
        Camera.main.fieldOfView = m_FieldOfView;
    }
}