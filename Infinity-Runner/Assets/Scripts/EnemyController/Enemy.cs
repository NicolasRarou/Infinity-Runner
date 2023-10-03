using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public int health = 1;
    public int damage = 2; 

    public virtual void ApplyDamage(int dmg) // Aplica o Dano nos inimigos
    {
        health -= dmg;
        
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision) //Checa colisão entre a bala do jogador e os inimigos
    {
        if (collision.CompareTag("Bullet"))
        {
            
            ApplyDamage(collision.GetComponent<PlayerProjectile>().damage);
            collision.GetComponent<PlayerProjectile>().OnHit();
        }

    }

}
