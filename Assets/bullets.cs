using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class bullets : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * (10f);
    }
}

//look here for fixing prob maybe https://www.youtube.com/watch?v=wZ2UUOC17AY