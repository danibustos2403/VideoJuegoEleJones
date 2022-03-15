using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cofrePistola : MonoBehaviour
{
    public AudioClip chestSfx;
    private GameManager gameManager;
    private GameObject gameObject;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager.tengoPistola)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MovimientoJugadora>().CogerPistola();

            collision.GetComponent<AudioSource>().PlayOneShot(chestSfx);

            Destroy(gameObject);


            gameObject = GameObject.Find("Torre").GetComponent<RigidBody2D>;
        }
    }
}
