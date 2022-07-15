using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    //permet d'�tre appel� n'importe ou
    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scene");
            return;
        }
        instance = this;

        // R�active les mouvements du joueur + qu'on lui rende sa vie
        gameOverUI.SetActive(false);
    }

    public void OnBikerHealth()
    {
        gameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
      

        // Recommencer le niveau
        // Recharge la sc�ne
        SceneManager.LoadScene("GAME");
        
       

    }

    public void MainMenuButton()
    {
        //Retour au menu principale
        SceneManager.LoadScene("MENU");
       
    }

    public void QuitButton()
    {
        // Ferm� le jeu
        Application.Quit();
    }
}
