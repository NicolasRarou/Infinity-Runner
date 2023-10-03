using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private Rigidbody2D rb;

    public int damage;

    private Player player;

    public float xAxis;
    public float yAxis;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(xAxis, yAxis), ForceMode2D.Impulse); // fisica por trás do tiro da bomba
        Destroy(gameObject, 2f); //destroi a bomba após 2 segundos
    }

     void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // checa se a bomba acertou o jogador
        {
            player.OnTakingDamage(damage); //aplica o dano de 2 no jogador caso a bomba o acerte
        }
    }

}
