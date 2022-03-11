using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Final : MonoBehaviour
{
    private GameManager gameManager;
    public TextMeshProUGUI textoTitulo;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        textoTitulo.text = gameManager.getMensajeFinal();
    }
}
