using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public bool isSetUp;
    public int enemyCount;
    public int currWave;


    // Start is called before the first frame update
    void Start()
    {
        isSetUp = true;
        currWave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSetUp)
        {

        }
    }
}
