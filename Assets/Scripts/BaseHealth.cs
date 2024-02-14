using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public int _BaseHealth = 3;
    public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_BaseHealth <= 0)
        {
            Debug.Log("im ded");
            Destroy(self);
        }
    }
}
