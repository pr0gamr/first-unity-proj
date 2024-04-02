using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceenemy : MonoBehaviour
{
    private Transform self;
    Collider[] colliders = new Collider[2000];
    float Range = 100;
    Transform bestTarget = null;
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Transform>();
    }

    // Update is called once per frame
    void update()
    {
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, Range, colliders);
        if (numColliders > 0)
        {
            for (int i = 0; i < numColliders; i++)
            {
                if (colliders[i].gameObject.tag == "Enemy")
                {
                    bestTarget = null;
                    float closestDistance = Range + 1;
                    Transform Enemyobj = colliders[i].GetComponent<Transform>();
                    if(Enemyobj != null)
                    {
                        Vector3 directionToTarget = Enemyobj.position - self.position;
                        float dSqrToTarget = directionToTarget.sqrMagnitude;
                        if(dSqrToTarget < closestDistance)
                        {
                            closestDistance = dSqrToTarget;
                            bestTarget = Enemyobj.transform;
                        }
                    }


                    if(Range == 1000)
                    {
                    Debug.Log(colliders[i].GetComponent<Collider>().tag);
                    GameObject Enemy = colliders[i].GetComponent<Collider>().gameObject;
                    Enemy.GetComponent<EnemyKillCheck>().Health -= 1;
                    }
                }
            }  
        }
    
        if(bestTarget != null)
            {
                self.transform.LookAt(bestTarget.transform);
            }
    }
}
