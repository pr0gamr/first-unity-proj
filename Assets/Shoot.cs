using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private bool isshootpressed = false;
    public GameObject objectToSpawn;

    void Update()
    {
        isshootpressed = Input.GetButtonDown("Fire1");
        if (isshootpressed)
        {
       Instantiate(objectToSpawn);
       Debug.Log("shoot");
        }
    }
}
//