using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceenemy : MonoBehaviour
{
    public Transform self;
    Collider[] colliders = new Collider[2000];
    float Range = 100;
    Transform bestTarget = null;
    float closestDistance;
    float dSqrToTarget;
    // Start is called before the first frame update
    void Start()
    {
        closestDistance = Range + 1;
        ///self = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        int numColliders = Physics.OverlapSphereNonAlloc(self.position, Range, colliders);
        if (numColliders > 0)
        {
            //Debug.Log(numColliders);
            for (int i = 0; i < numColliders; i++)
            {
                if (colliders[i].gameObject.tag == "Enemy")
                {
                    Transform Enemyobj = colliders[i].GetComponent<Transform>();
                    if(Enemyobj != null)
                    {
                        Vector3 directionToTarget = Enemyobj.position - self.position;
                        dSqrToTarget = directionToTarget.sqrMagnitude;
                        if(dSqrToTarget < closestDistance)
                        {
                            closestDistance = dSqrToTarget;
                            bestTarget = Enemyobj.transform;
                        }
                    }
                    
                    if(Range == 1000)
                    {
                        //Debug.Log(colliders[i].GetComponent<Collider>().tag);
                        GameObject Enemy = colliders[i].GetComponent<Collider>().gameObject;
                        Enemy.GetComponent<EnemyKillCheck>().Health -= 1;
                    }
                }
            }  
        }
    
        if(bestTarget != null)
        {
            self.LookAt(bestTarget.position, Vector3.up);
            //Debug.Log(bestTarget.gameObject);
            bestTarget = null;
            closestDistance = Range + 1;
            //Debug.Log(bestTarget);
        }
    }
}
