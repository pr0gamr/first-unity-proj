using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public NavMeshAgent Enemy;
    public Transform Player;
    public Transform Target;

    void Start()
    {
        Enemy.SetDestination(Target.position);
        Debug.Log(Target.position);
    }
    // Update is called once per frame
    void Update()
    {
        //Enemy.SetDestination(Player.position);
        //Debug.Log(Player.position);
    }
} 
