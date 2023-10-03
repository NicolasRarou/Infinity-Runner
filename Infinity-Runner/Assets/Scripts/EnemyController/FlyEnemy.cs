using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyEnemy : Enemy
{

    private Player player;

    private Rigidbody2D rb;
    [SerializeField] private float flyEnemySpeed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    void Update()
    {

        rb.velocity = Vector2.left * flyEnemySpeed;

    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.OnTakingDamage(damage);
        }
        
    }
}
