using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public NavMeshAgent Enemy;
    public Transform Player;

    // Update is called once per frame
    void Update()
    {
        Enemy.SetDestination(Player.position);
        //Debug.Log(Player.position);
    }
}
