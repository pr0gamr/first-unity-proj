using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTurret : MonoBehaviour
{

    public GameObject turret;
    void Update()
    {
        if (GetComponent<Movement>().overHead && Input.GetMouseButtonDown(0))
        {
            Ray ray = GetComponent<Movement>().overheadCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Transform place = hit.point;
                Instantiate(turret, hit.position);
                Debug.Log(hit.point);
                Debug.Log("turmnet");
            }
        }
    }
}
