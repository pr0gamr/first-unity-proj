using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class bullets : MonoBehaviour
{
    public Rigidbody rb;
    public Transform direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(direction.up * 50);
    }
}

//look here for fixing prob maybe https://www.youtube.com/watch?v=wZ2UUOC17AY