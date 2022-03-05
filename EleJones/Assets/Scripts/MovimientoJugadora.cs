using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugadora : MonoBehaviour
{
    // Variables
    [Range(1, 10)] public float speed;
    Rigidbody2D rb2d;
    SpriteRenderer spRd;

    private Animator animator;
    bool isJumping = false;
    [Range(1, 500)] public float potenciaSalto;
    public float gemas;

    //Variable para vida de powerUp
    [Range(0, 5)] public int vida;
    public bool vulnerable; //indica cuando estamos vulnerables
    bool isDead;

    //Para atacar en melee
    public bool isMelee;
    public bool tengoCuchillo;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spRd = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetBool("isDead", false);
        vulnerable = true;
        gemas = 0;
        tengoCuchillo = false;
        isMelee = false;
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void FixedUpdate()
    {
        if (!isDead)
        {
            float movimientoH = Input.GetAxisRaw("Horizontal");
            rb2d.velocity = new Vector2(movimientoH * speed, rb2d.velocity.y);
            
            //Control de la direcci�n del mu�eco
            if (movimientoH > 0)
                spRd.flipX = false;
            else if (movimientoH < 0)
                spRd.flipX = true;

            //Control de la animaci�n
            if (movimientoH != 0)
                animator.SetBool("isWalking", true);
            else
                animator.SetBool("isWalking", false);

            //Para el salto
            if (Input.GetButton("Jump") && !isJumping)
            {
                rb2d.AddForce(Vector2.up * potenciaSalto);
                isJumping = true;
                animator.SetBool("isJumping", isJumping);
            }


            //Para usar el cuchillo
            if (Input.GetButton("Fire1") && tengoCuchillo) //pulso la tecla CTRL
            {
                isMelee = true;
                animator.SetBool("isMelee", isMelee);
                Invoke("PararMelee", 2.5f);
            }
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }

    //Controlar� la colisi�n contra el suelo, para los saltos
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isJumping = false;
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            animator.SetBool("isJumping", isJumping);
        }
    }

    public void IncrementarVida(int cantidad)
    {
        vida += cantidad;
    }

    public void DecrementarVida(int cantidad)
    {
        if (vulnerable && !isDead)
        {
            vulnerable = false;
            vida -= cantidad;

            if(vida <= 0)
            {
                isDead = true;
                animator.SetBool("isDead", isDead);
                Invoke("ReanudarPartida", 2.5f);
            }
            else
            {
                Invoke("HacerVulnerable", 1f);
                spRd.color = Color.red;
            }
        }   
    }

    private void HacerVulnerable()
    {
        vulnerable = true;
        spRd.color = Color.white;
    }

    private void ReanudarPartida()
    {
        isDead = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void IncrementarGemas(int cantidad)
    {
        gemas += cantidad;
    }

    public void CogerCuchillo()
    {
        tengoCuchillo = true;
    }

    private void PararMelee()
    {
        isMelee = false;
        animator.SetBool("isMelee", isMelee);
    }
}
