using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceenemy : MonoBehaviour
{
    public Transform self;
    Collider[] colliders = new Collider[2000];
    float Range = 100;
    float fireRate = 2;
    float coolDown;
    Transform bestTarget = null;
    float closestDistance;
    float dSqrToTarget;
    public Transform barrelEnd1;
    public Transform barrelEnd2;
    public LineRenderer lineRend;
    public LineRenderer lineRend2;
    // Start is called before the first frame update
    void Start()
    {
        closestDistance = Range + 1;
        //makes it easier to set how fast it fires
        fireRate = (60 / fireRate);
        coolDown = fireRate;
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

        if(coolDown > 0)
        {
            coolDown -= 1;
        }
        if(bestTarget != null)
        {
            self.LookAt(bestTarget.position, Vector3.up);
            if(coolDown == 0)
            {
                RaycastHit hit; 
                if(Physics.Raycast(self.position, self.forward, out hit))
                {
                    Debug.Log(hit.collider.tag);
                    if(hit.collider.tag == "Enemy")
                    {
                        //Debug.Log(hit.collider.tag);
                        GameObject Enemy = hit.collider.gameObject;
                        Enemy.GetComponent<EnemyKillCheck>().Health -= 1;
                    }
                }

                lineRend.enabled = true;
                lineRend.SetPosition(0, barrelEnd1.position);
                lineRend.SetPosition(1, hit.point);

                lineRend2.enabled = true;
                lineRend2.SetPosition(0, barrelEnd2.position);
                lineRend2.SetPosition(1, hit.point);

                StartCoroutine(Despawn());
                coolDown = fireRate;
            }
            bestTarget = null;
            closestDistance = Range + 1;
        }
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(0.02f);
        lineRend.enabled = false;
        lineRend2.enabled = false;
    }
}
