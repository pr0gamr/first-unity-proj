using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeath : MonoBehaviour
{
    public float lifeTime = 1f;     //How many seconds(or fraction thereof) this object will survive
    private bool timeToDie = false;    //The object's trigger of its inevitable DEATH!!!
 
    void Update ()
    {
        lifeTime -= Time.deltaTime;
 
        if (lifeTime <= 0.0f)
        {
            timeToDie = true;
        }
 
        if (timeToDie == true)
        {
            Destroy (gameObject);
        }
    }
}
