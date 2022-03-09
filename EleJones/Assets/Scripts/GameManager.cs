using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject gameManager;
    public int vidasGlobal { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        DontDestroyOnLoad(gameManager);
        SceneManager.LoadScene("Menu");
    }

    public void cambiarEscena(string siguienteScene)
    {
        SceneManager.LoadScene(siguienteScene);
    }

    public void inicializarVidas()
    {
        vidasGlobal = 3;
    }

    public int getVidas()
    {
        return vidasGlobal;
    }

    public void decrementarVidas()
    {
        vidasGlobal--;
    }
    public void aumentarVidas()
    {
        vidasGlobal++;
    }
}