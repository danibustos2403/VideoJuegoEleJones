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

    //Variable para vida de powerUp
    [Range(0, 5)] public int vida;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spRd = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
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
        vida -= cantidad;
    }
}
