using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombEnemy : Enemy
{
    public GameObject bombPrefab;
    public Transform firePoint;


    public float throwTime;
    private float throwCount;

    void Start()
    {
        
    }


    void Update()
    {

        throwCount += Time.deltaTime;

        if (throwCount >= throwTime)
        {
            //arremesso da bomba
            Instantiate(bombPrefab, firePoint.position, firePoint.rotation); //instancia a bomba do inimigo
            throwCount = 0f;

        }

    }

}
