using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int health; 

    private Rigidbody2D rb;

    public Animator anim;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private bool isJumping;


    public GameObject projectileA;
    public Transform firePoint; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Bullet();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) //Input de pulo
        {
            OnJump();

        }
           
    }

   public void OnJump()
    {
        if (!isJumping)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); //Fisica de pulo
            anim.SetBool("Jump", true);
            isJumping = true;

        }
          
    }

    public void Bullet() //Função de tiro
    {
            Instantiate(projectileA, firePoint.position, firePoint.rotation); //Instancia o prefab do projetil apartir da posição do firepoint
    }


    public void OnTakingDamage(int dmg) //Função de dano
    {
        health-= dmg;
        
        if(health <= 0)
        {
            GameController.instance.ShowGameOver(); //Aplica a tela de game over caso o player zere o HP
        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.layer == 6) // Checa se o player está no chão ou não
        {
            anim.SetBool("Jump", false);
            isJumping = false;

        }


    }


}
