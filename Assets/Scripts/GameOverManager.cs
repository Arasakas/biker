using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    //permet d'être appelé n'importe ou
    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scene");
            return;
        }
        instance = this;

        // Réactive les mouvements du joueur + qu'on lui rende sa vie
        gameOverUI.SetActive(false);
    }

    public void OnBikerHealth()
    {
        gameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
      

        // Recommencer le niveau
        // Recharge la scène
        SceneManager.LoadScene("GAME");
        
       

    }

    public void MainMenuButton()
    {
        //Retour au menu principale
        SceneManager.LoadScene("MENU");
       
    }

    public void QuitButton()
    {
        // Fermé le jeu
        Application.Quit();
    }
}
