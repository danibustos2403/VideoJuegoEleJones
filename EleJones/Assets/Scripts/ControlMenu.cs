using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    private GameManager gameManager;

    public void OnButtonJugar()
    {
        gameManager = FindObjectOfType<GameManager>();
        
        gameManager.inicializarVidas();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //Carga la escena que viene a continuación
    }

    public void OnButtonCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void OnButtonSalir()
    {
        Application.Quit(); //Sale del juego
    }

    public void OnButtonMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
