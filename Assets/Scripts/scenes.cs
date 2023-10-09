using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Scene1"))
        {
            SceneManager.LoadScene("Test");
        }
                if (Input.GetButtonDown("Scene2"))
        {
            SceneManager.LoadScene("Destructable");
        }
                if (Input.GetButtonDown("Scene3"))
        {
            SceneManager.LoadScene("flash");
        }
    }
}
