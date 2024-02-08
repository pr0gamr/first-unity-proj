using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillCheck : MonoBehaviour
{
    public float Health = 10f;
    public GameObject self;

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            Destroy(self);
        }
    }
}
