using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody objectToSpawn;
    public Rigidbody objectTwoSpawn;
    public Rigidbody objectThreeSpawn;
    public Rigidbody objectFourSpawn;
    public Transform Objectarrow;
    public Rigidbody objectFiveSpawn;
    public Transform barrelEnd;
    public Transform direction;
    float LoadOut = 1;
    float m_FieldOfView;
    float Sensitivity;
    bool reloading;
    float ARfireDown;

    void start()
    {
        m_FieldOfView = 60.0f;
    }

    void Update()
    {
        m_FieldOfView = 60.0f;
        Sensitivity = 2.8f;
        if(ARfireDown > 0)
        {
            ARfireDown -= 1;
        }
        if (LoadOut == 1)
        {
            if (Input.GetButton("Fire1") && ARfireDown == 0)
            {
                Rigidbody bullet;
                bullet = Instantiate(objectToSpawn, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
                bullet.GetComponent<Rigidbody>().AddForce(direction.forward * 7500);
                ARfireDown = 25;
                //Debug.Log("shoot");
            }
            if (Input.GetButtonDown("Fire2"))
            {
                Rigidbody bullet2;
                bullet2 = Instantiate(objectTwoSpawn, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
                bullet2.GetComponent<Rigidbody>().AddForce(direction.forward * 5000);
                //Debug.Log("shoot2");
            }
        }
        else if (LoadOut == 2)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Rigidbody bullet3;
                bullet3 = Instantiate(objectThreeSpawn, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
                bullet3.GetComponent<Rigidbody>().AddForce(direction.forward * 50000);
                //Debug.Log("shoot3");
            }
            if (Input.GetButtonDown("Fire2"))
            {
                Rigidbody bullet2;
                bullet2 = Instantiate(objectFourSpawn, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
                bullet2.GetComponent<Rigidbody>().AddForce(direction.forward * 5000);
                //Debug.Log("shoot2");
            }
        }
        else if (LoadOut == 3)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Rigidbody bullet3;
                bullet3 = Instantiate(objectFiveSpawn, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
                bullet3.GetComponent<Rigidbody>().AddForce(direction.forward * 5000000);
                //Debug.Log("sniper");
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

    void OnGUI() 
    {
        GUI.Label(new Rect(10, 10, 500, 20), "loadout : " + LoadOut.ToString());
        if(LoadOut == 1)
        {
            GUI.Label(new Rect(10, 25, 500, 20), "Left click : Assault rifle" + " | Right click : Bounce shot");
        }
        else if(LoadOut == 2)
        {
            GUI.Label(new Rect(10, 25, 500, 20), "Left click : Cannon ball" + " | Right click : Ballista shot");
        }
        else if(LoadOut == 3)
        {
            GUI.Label(new Rect(10, 25, 500, 20), "Left click : Sniper rifle" + " | Right click : Zoom");
        }
    }
}