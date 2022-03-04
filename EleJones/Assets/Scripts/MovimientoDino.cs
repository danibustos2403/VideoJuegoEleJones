using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDino : MonoBehaviour
{
    public float velocidad;
    
    public Vector3 posicionFin;
    private Vector3 posicionInicio;

    private bool movimientoAFin;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicio = transform.position;
        movimientoAFin = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoverEnemigo();
    }

    private void MoverEnemigo()
    {
        Vector3 posicionDestino = (movimientoAFin) ? posicionFin : posicionInicio; //si moviento es true a posicion destino le asignamos posicionFin y si no posicionInicio
        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);

        if (transform.position == posicionFin)
            movimientoAFin = false;

        if (transform.position == posicionInicio)
            movimientoAFin = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<MovimientoJugadora>().DecrementarVida(1);
        }
    }
}