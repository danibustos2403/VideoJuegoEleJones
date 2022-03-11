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

    //Control del canvas
    public Canvas canvas;
    private ControlHUD hud;

    //Control objeto GameManager, para el control de vidas al cambiar de escena
    private GameManager gameManager;

    //Control joystick
    public Joystick joystick;

    //Control boton acuchillar
    private GameObject botonMelee;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spRd = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        animator.SetBool("isDead", false); //Asignamos a false la variable isDead para no activar la animacion de morir
        vulnerable = true; //Vulnerable = true para que pueda ser dañado
        gemas = 0; //inicializamos las gemas

        //Animación acuchillar
        tengoCuchillo = false;
        isMelee = false;
        botonMelee = GameObject.Find("BtnMelee");
        botonMelee.SetActive(false);

        //Control de vidas con el game manager
        gameManager = FindObjectOfType<GameManager>();

        //Control del canvas
        hud = canvas.GetComponent<ControlHUD>();
        //hud.setVidasTxt(vida); //Control de vidas del HUD, sin el GameManager
        hud.setVidasTxt(gameManager.getVidas());
    }

    // Update is called once per frame
    void Update()
    {
        //Control de powerUps del HUD
        hud.setPowerUpTxt(GameObject.FindGameObjectsWithTag("Diamond").Length);
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            //float movimientoH = Input.GetAxisRaw("Horizontal");

            //Movimiento con joystick
            float movimientoH;
            
            if((joystick.Horizontal >= .2f) || (joystick.Horizontal <= -.2f))
                movimientoH = joystick.Horizontal;
            else
                movimientoH = 0f;
            

            rb2d.velocity = new Vector2(movimientoH * speed, rb2d.velocity.y);
            
            //Control de la dirección del muñeco
            if (movimientoH > 0)
                spRd.flipX = false;
            else if (movimientoH < 0)
                spRd.flipX = true;

            //Control de la animación
            if (movimientoH != 0)
                animator.SetBool("isWalking", true);
            else
                animator.SetBool("isWalking", false);

            //Para el salto
            /**
            float movimientoV = joystick.Vertical;
            //if (Input.GetButton("Jump") && !isJumping)
            if(movimientoV >= .5f && !isJumping)
            {
                rb2d.AddForce(Vector2.up * potenciaSalto);
                isJumping = true;
                animator.SetBool("isJumping", isJumping);
            }
            */

            if (tengoCuchillo)
                botonMelee.SetActive(true);

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

    //Controlará la colisión contra el suelo, para los saltos
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
        gameManager.aumentarVidas();
        hud.setVidasTxt(gameManager.getVidas()); //Actualizamos vidas del HUD
    }

    public void DecrementarVida()
    {
        if (vulnerable && !isDead)
        {
            vulnerable = false;
            gameManager.decrementarVidas();

            if(gameManager.getVidas() <= 0)
            {
                isDead = true;
                animator.SetBool("isDead", isDead);
                Invoke("ReanudarPartida", 2.5f);

                if (gameManager.getVidas() == 0)
                {
                    gameManager.TerminarJuego(false);
                }
            }
            else
            {
                Invoke("HacerVulnerable", 1f);
                spRd.color = Color.red;
            }
        }
        //Actualizamos vidas del HUD
        hud.setVidasTxt(gameManager.getVidas());
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

    //Boton acuchillar
    public void btnMelee()
    {
        isMelee = true;
        animator.SetBool("isMelee", isMelee);
        Invoke("PararMelee", 2.5f);
    }
    //Boton salto
    public void btnJump()
    {
        if (!isJumping)
        {
            rb2d.AddForce(Vector2.up * potenciaSalto);
            isJumping = true;
            animator.SetBool("isJumping", isJumping);
        }
    }
}
