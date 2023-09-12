using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;
    public Vector3 deltaMove;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed, 0, Input.GetAxisRaw("Vertical") * speed);
    }
}
