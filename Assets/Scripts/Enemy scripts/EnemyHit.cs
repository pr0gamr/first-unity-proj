using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public GameObject self;
    
    void OnCollisionEnter(Collision otherObj) 
    {
        if (otherObj.gameObject.tag == "Home") 
        {
            GameObject Base = otherObj.gameObject;
            Base.GetComponent<BaseHealth>()._BaseHealth -= 1;
            Destroy(self);
            Debug.Log(Base.GetComponent<BaseHealth>()._BaseHealth);
            Debug.Log(self);
        }
    }
}
