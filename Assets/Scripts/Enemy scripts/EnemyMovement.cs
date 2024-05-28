using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public NavMeshAgent Enemy;
    public GameObject PlayerObj;
    public GameObject TargetObj;

    void Start()
    {
        TargetObj = GameObject.FindGameObjectWithTag("Home");
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        Transform Player = PlayerObj.GetComponent<Transform>();
        Transform Target = TargetObj.GetComponent<Transform>();
        Enemy.SetDestination(Target.position);
        Debug.Log(Target.position);
    }
    // Update is called once per frame
    //void Update()
    //{
        //Enemy.SetDestination(Player.position);
        //Debug.Log(Player.position);
    //}
} 
