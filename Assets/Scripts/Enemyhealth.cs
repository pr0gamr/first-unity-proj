using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public float Health = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision otherObj) 
    {
        if (otherObj.gameObject.tag == "Enemy") 
        {
            otherObj.Health -= 1;
        }
    }
}
