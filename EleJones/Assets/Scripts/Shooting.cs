using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float Velocidad = 50.0F;

    //Variables privadas
    private Rigidbody thisRigidbody;

    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        thisRigidbody.transform.Translate(new Vector3(Velocidad, 0, 0) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemigo")
        {
            //Si el ataque colisiona contra un objeto con el tag 'Enemigo'
            other.gameObject.GetComponent<MovimientoDino>().DinoDisparado();

            //Destruimos el objeto cuando colisione contra un enemigo
            Destroy(gameObject);
        }
    }
}
