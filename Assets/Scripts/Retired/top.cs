using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top : MonoBehaviour
{
    // Already reference this via the Inspector if possible
    [SerializeField] private Camera _camera;
    // Adjust how far in front of the camera the object should spawn
    [SerializeField] private float distance = 5;
    
    public Rigidbody _top;
    public Transform direction;

    private void Awake ()
    {
        // otherwise get it ONCE
        if(!_camera) _camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Top"))
        {
            Rigidbody Top;
            Top = Instantiate(_top, _camera.transform.position + _camera.transform.forward * distance, _camera.transform.rotation);
            Top.AddForce(direction.forward * 2000);
            Top.AddTorque(Vector3.up * 20000000);
        }
    }
}
