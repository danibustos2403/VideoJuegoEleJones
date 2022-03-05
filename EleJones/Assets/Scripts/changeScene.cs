using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public string nextScene;
    //private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = FindObjectOfType<gameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(nextScene);
    }
}
