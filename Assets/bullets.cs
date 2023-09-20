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
       rb.velocity = new Vector3(0, 0, 10);
       Vector3 direction = Vector3.forward;
    }
}