using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;


    public static GameController instance; 

    void Start()
    {

        instance = this;
        Time.timeScale = 1;

       
    }

    public void ShowGameOver() // m�todo para mostrar a tela de game over
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;

    }
  

    public void RestartGame() //m�todo para reiniciar o jogo caso o player morra
    {
        SceneManager.LoadScene(0); //Classe e m�todo para recarregar a cena
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(1);
    }
}
