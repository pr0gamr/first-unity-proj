using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject PlayerVar;
    public Transform Player;
    public Rigidbody objectToSpawn;
    [SerializeField] Transform gunEnd;
    public LineRenderer lineRend;
    public Rigidbody objectTwoSpawn;
    public Rigidbody objectThreeSpawn;
    public Rigidbody objectFourSpawn;
    public Transform Objectarrow;
    public Rigidbody objectFiveSpawn;
    public Rigidbody objectSixSpawn;
    public Rigidbody objectSevenSpawn;
    [SerializeField] ParticleSystem FlameThrower;
    [SerializeField] ParticleSystem ColdThrower;
    public Transform barrelEnd;
    public Transform direction;
    float LoadOut = 1;
    float m_FieldOfView = 60.0f;
    bool reloading = false;
    float ARfireDown;
    float FlameDown;
    float ColdDown;
    bool topDown;
    float ARfireRate = 6;
    int test;
    public AudioSource source;
    public AudioClip shot;
    public Camera fpsCamera;

    void Start()
    {
        lineRend.SetPosition(0, gunEnd.position);
        lineRend.SetPosition(1, gunEnd.position);
        lineRend.enabled = false;
    }

    void Update()
    {
        if(PlayerVar.GetComponent<Movement>().overHead == false)
        {
            topDown = false;
            var localOffset = new Vector3(0, 0, 2);
            var worldOffset = barrelEnd.rotation * localOffset;
            var spawnPosition = Player.position + worldOffset;

            m_FieldOfView = 60.0f;

            if (LoadOut == 1)
            {
                if (Input.GetButton("Fire1") && ARfireDown == 0)
                {
                    ARfireDown = 1;
                    StartCoroutine(ARcooldown());
                   RaycastHit hit; 
                   if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit))
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
                   lineRend.SetPosition(0, gunEnd.position);
                   lineRend.SetPosition(1, hit.point);
                   StartCoroutine(Despawn());
                   
                    if(source != null && !source.isPlaying)
                    {
                        source.clip = shot;
                        source.Play();
                    }
                    //else if(source != null && source.isPlaying)
                    //{
                        //source.Stop();
                    //}
                }
                else if (Input.GetButtonDown("Fire2"))
                {
                    Rigidbody bullet2;
                    bullet2 = Instantiate(objectTwoSpawn, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
                    bullet2.GetComponent<Rigidbody>().AddForce(direction.forward * 5000);
                    //Debug.Log("shoot2");
                }
            }
            else if (LoadOut == 2)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Rigidbody bullet1;
                    bullet1 = Instantiate(objectThreeSpawn, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
                    bullet1.GetComponent<Rigidbody>().AddForce(direction.forward * 50000);
                    //Debug.Log("shoot3");
                }
                if (Input.GetButtonDown("Fire2"))
                {
                    Rigidbody bullet2;
                    bullet2 = Instantiate(objectFourSpawn, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
                    bullet2.GetComponent<Rigidbody>().AddForce(direction.forward * 5000);
                    //Debug.Log("shoot2");
                }
            }
            else if (LoadOut == 3)
            {
                if(Input.GetButtonDown("Fire1"))
                {
                    Rigidbody bullet1;
                    bullet1 = Instantiate(objectFiveSpawn, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
                    bullet1.GetComponent<Rigidbody>().AddForce(direction.forward * 5000000);
                    //Debug.Log("sniper");
                }
                
                if (Input.GetButton("Fire2"))
                {
                    m_FieldOfView = 10f;
                }
            }
            else if (LoadOut == 4)
            {
                if(Input.GetButtonDown("Fire1"))
                {
                    Rigidbody bullet1;
                    bullet1 = Instantiate(objectSixSpawn, spawnPosition, barrelEnd.rotation) as Rigidbody;
                    bullet1.GetComponent<Rigidbody>().AddForce(direction.forward * 50);
                    //Debug.Log("sniper");
                }
                if(Input.GetButtonDown("Fire2"))
                {
                    Rigidbody bullet2;
                    bullet2 = Instantiate(objectSevenSpawn, spawnPosition, barrelEnd.rotation) as Rigidbody;
                    bullet2.GetComponent<Rigidbody>().AddForce(direction.forward * 500000);
                    //Debug.Log("sniper");
                }
            }
            else if (LoadOut == 5)
            {
                if(Input.GetButton("Fire1"))
                {
                    Debug.Log("meep");
                    Instantiate(FlameThrower, barrelEnd.position, barrelEnd.rotation);
                    //Debug.Log(FlameThrower.isPlaying);
                    //if(FlameThrower.isPlaying)
                    //{
                    //    FlameThrower.Stop();
                        //Debug.Log("FIRE");
                    //}
                    //Debug.Log(FlameThrower.isPlaying);
                    //if(!FlameThrower.isPlaying)
                    //{
                    //        FlameThrower.Play();
                    //}
                }
                //if(Input.GetButtonUp("Fire1"))
                //{
                //    FlameThrower.Stop();
                //}
                if(Input.GetButtonDown("Fire2"))
                {
                
                    ColdThrower.Play();
                    Debug.Log("COLD");
                
                }
            }
            if (Input.GetButtonDown("Fire3"))
            {
                if (LoadOut == 1)
                {
                    LoadOut = 2;
                }
                else if (LoadOut == 2)
                {
                    LoadOut = 3;
                }
                else if (LoadOut == 3)
                {
                    LoadOut = 4;
                }
                else if (LoadOut == 4)
                {
                    LoadOut = 5;
                }
                else if (LoadOut == 5)
                {
                    LoadOut = 1;
                }
                Debug.Log(LoadOut);
            }

                Camera.main.fieldOfView = m_FieldOfView;
        }
        else 
        {
            topDown = true;
        }
    }

    void OnGUI() 
    {
        if (topDown == false)
        {
            GUI.Label(new Rect(10, 10, 500, 20), "loadout : " + LoadOut.ToString());
            if(LoadOut == 1)
            {
                GUI.Label(new Rect(10, 25, 500, 20), "Left click : Assault rifle" + " | Right click : Bounce shot");
            }
            else if(LoadOut == 2)
            {
                GUI.Label(new Rect(10, 25, 500, 20), "Left click : Cannon ball" + " | Right click : Ballista shot");
            }
            else if(LoadOut == 3)
            {
                GUI.Label(new Rect(10, 25, 500, 20), "Left click : Sniper rifle" + " | Right click : Zoom");
            }
            else if(LoadOut == 4)
            {
                GUI.Label(new Rect(10, 25, 500, 20), "Left click : rocket" + " | Right click : meator");
            }
            else if(LoadOut == 5)
            {
                GUI.Label(new Rect(10, 25, 500, 20), "Left click : Flame Thrower" + " | Right click : Cold Thrower");
            }
        }
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(0.02f);
        lineRend.enabled = false;
    }
    IEnumerator ARcooldown()
    {
        test += 1;
        if(reloading == false)
        {
            reloading = true;
            StartCoroutine(testingsps());
        }
        yield return new WaitForSeconds(60/ARfireRate/60);
        source.Stop();
        ARfireDown = 0;
    }
    IEnumerator testingsps()
    {
        yield return new WaitForSeconds(1);
        print(test);
        test = 0;
        reloading = false;
    }
}