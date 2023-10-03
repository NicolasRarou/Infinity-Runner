using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmFlyEnemies : MonoBehaviour
{

    public List<GameObject> enemiesList = new List<GameObject>();

    private float timeCount;
    public float SpawnTime;

    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        timeCount += Time.deltaTime;
        if(timeCount >=SpawnTime)
        {
            //instancia de inimigos
            SpawnEnemy();
            timeCount = 0f;
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemiesList[Random.Range(0, enemiesList.Count)], transform.position + new Vector3(0, Random.Range(0f, 2f), 0), transform.rotation);
    }
}
