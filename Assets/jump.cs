using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
 public Rigidbody rb;
 
    private bool isJetPressed = false;
    private bool isJumpPressed = false;
    private float _distanceToTheGround = 0.0f;


    bool CheckGround()
    {
        _distanceToTheGround = GetComponent<Collider>().bounds.extents.y;
        return Physics.Raycast(transform.position, Vector3.down, _distanceToTheGround + 0.1f);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(CheckGround())
        {
         isJumpPressed = Input.GetButtonDown("Jump");
            if (isJumpPressed)
         {
             // the cube is going to move upwards in 10 units per second
             rb.velocity = new Vector3(0, 10, 0);
              Debug.Log("jump");
           }
        }
         isJetPressed = Input.GetButton("Jet");
            if (isJetPressed)
            {
                rb.velocity = new Vector3(0, 10, 0);
                Debug.Log("jet");
            }
    }
}
   