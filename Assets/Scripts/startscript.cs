using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startscript : MonoBehaviour
{
    public int started;
    public Camera startcam;
    // Start is called before the first frame update
    void Start()
    {
        started = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(started == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = startcam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.tag == "Start")
                    {
                        started = 1;
                        SceneManager.LoadScene("The_Lab");
                    }
                }
            }
        }    
    }
}
