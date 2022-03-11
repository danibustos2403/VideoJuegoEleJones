using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject gameManager;
    public int vidasGlobal { get; set; }
    private string mensajeFinal;

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

    public string getMensajeFinal()
    {
        return mensajeFinal;
    }

    public void decrementarVidas()
    {
        vidasGlobal--;
    }
    public void aumentarVidas()
    {
        vidasGlobal++;
    }

    public void TerminarJuego(bool ganar)
    {
        mensajeFinal = (ganar) ? "Felicidades has terminado el juego" : "Has perdido!";
        cambiarEscena("Final");
    }
}