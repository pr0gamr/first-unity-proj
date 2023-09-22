using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeath : MonoBehaviour
{
    public float lifetime = 10f;     //How many seconds(or fraction thereof) this object will survive

    void Start () {
    Destroy (gameObject, lifetime);
    }
}
