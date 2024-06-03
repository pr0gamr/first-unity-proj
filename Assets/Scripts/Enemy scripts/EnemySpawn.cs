using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public Transform self;
    public bool isSetUp;
    public int enemyCount;
    public int currWave;
    public int maxEnemy;
    public int enemySpawned;
    public bool waveStart;


    // Start is called before the first frame update
    void Start()
    {
        enemySpawned = 0;
        isSetUp = true;
        currWave = 1;
        waveStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSetUp && !waveStart)
        {
            Debug.Log("start");
            waveStart = true;
            maxEnemy += Random.Range(3, 10);
            StartCoroutine(enemyTick());
        }

        if (Input.GetButtonDown("Scene1"))
        {
            isSetUp = false;
        }
    }

    IEnumerator enemyTick()
    {
        Debug.Log("Tick");
        if (enemySpawned < maxEnemy)
        {
            enemySpawned++;
            Instantiate(Enemy, self.position, self.rotation);
        }

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
        if(enemyCount == 0)
        {
            waveStart = false;
            isSetUp = true;
            currWave++;
        }
        else
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(enemyTick());
        }
    }
}
