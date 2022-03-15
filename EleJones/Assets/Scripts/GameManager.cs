using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject gameManager;
    public int vidasGlobal { get; set; }
    public int starsLevel1 { get; set; }
    public int starsLevel2 { get; set; }
    public int starsLevel3 { get; set; }
    public bool tengoCuchillo { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        DontDestroyOnLoad(gameManager);
        SceneManager.LoadScene("Menu");
        tengoCuchillo = false;

        starsLevel1 = 0;
        starsLevel2 = 0;
        starsLevel3 = 0;
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
    public void aumentarVidas(int cantidad)
    {
        vidasGlobal += cantidad;
    }

    public void TerminarJuego(bool ganar)
    {
        if (ganar)
            cambiarEscena("YouWin");
        else
            cambiarEscena("YouLose");
    }
}