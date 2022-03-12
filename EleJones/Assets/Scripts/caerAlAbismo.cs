using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caerAlAbismo : MonoBehaviour
{
    private GameManager gameManager;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            gameManager = FindObjectOfType<GameManager>();
            gameManager.TerminarJuego(false);
        }
    }
}
