using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class bullets : MonoBehaviour
{
    public Rigidbody rbs;
    public Transform direction;
    public GameObject self;
    [SerializeField] float explosionForce = 10;
    [SerializeField] float explosionRadius = 10;
    Collider[] colliders = new Collider[2000];

    void ExplodeNonAlloc()
    {
        //Debug.Log("Do something here");
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, explosionRadius, colliders);
        if (numColliders > 0)
        {
            for (int i = 0; i < numColliders; i++)
            {
                //Debug.Log("colliders = " + numColliders);
                //Debug.Log("i =" + i);

                if (colliders[i].TryGetComponent(out Rigidbody rb))
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                    //Debug.Log("transform = " + transform);
                    //Debug.Log("force = " + explosionForce);
                    //Debug.Log("radius = " + explosionRadius);
                    //Debug.Log("rb = " + rb);
                    //Debug.Log("boom");
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rbs = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        rbs.AddForce(direction.up * 25);
    }

//Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        Destroy(self);
        ExplodeNonAlloc();
        

        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "MyGameObjectName")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Do something here");
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "MyGameObjectTag")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
    }
}

//look here for fixing prob maybe https://www.youtube.com/watch?v=wZ2UUOC17AY
        //Vector3 explosionPos = transform.position;
        //Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        //foreach (Collider hit in colliders)
        //{
        //    Rigidbody rb = hit.GetComponent<Rigidbody>();
//
        //    if (rb != null)
        //        rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        //}