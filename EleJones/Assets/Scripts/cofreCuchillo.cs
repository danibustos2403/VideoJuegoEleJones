using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cofreCuchillo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MovimientoJugadora>().CogerCuchillo();
            Destroy(gameObject);
        }
    }
}
