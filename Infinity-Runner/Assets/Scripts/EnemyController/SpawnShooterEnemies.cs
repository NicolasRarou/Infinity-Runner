using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShooterEnemies : MonoBehaviour
{
    public GameObject enemyShooterPrefab;
    private GameObject currentEnemy;

    public List<Transform> points = new List<Transform>();


    void Start()
    {

        CreateShooterEnemy();

    }


    void Update()
    {
       ReSpawnEnemy();
        Destroy(currentEnemy, 10f);

    }

    public void ReSpawnEnemy()
    {
        if (currentEnemy == null) // checa se o inimigo foi destruído
        {
            //executa caso o inimigo seja destruído; 
            CreateShooterEnemy();
        }
    }

    void CreateShooterEnemy() //cria inimigos que atiram projeteis. 
    {
        int shooterPosition = Random.Range(0, points.Count);
        GameObject shooterSpawner = Instantiate(enemyShooterPrefab, points[shooterPosition].position, points[shooterPosition].rotation);
        currentEnemy = shooterSpawner;
    }

}
