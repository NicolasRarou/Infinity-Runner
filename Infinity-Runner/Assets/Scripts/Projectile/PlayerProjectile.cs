using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    private Rigidbody2D rb;
    public float projectileSpeed;

    public int damage;

    public GameObject explosionPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1f);
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.right * projectileSpeed;
    }

    public void OnHit() //Função que gera e destroi os tiros do jogador
    {
       GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation); //Instancia os tiros do jogador
        Destroy(explosion, 0.3f);
        Destroy(gameObject);
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6) //checa se a bala acertou a plataforma 
        {
            OnHit();
        }
    }
}
