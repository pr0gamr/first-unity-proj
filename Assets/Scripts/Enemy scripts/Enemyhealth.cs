using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public GameObject self;

    void OnCollisionEnter(Collision otherObj) 
    {
        if(otherObj.gameObject.tag != "Player")
        {
        Destroy(self);
        }
        
        if (otherObj.gameObject.tag == "Enemy") 
        {
            GameObject Enemy = otherObj.gameObject;
            Enemy.GetComponent<EnemyKillCheck>().Health -= 1;
        }
    }
}
