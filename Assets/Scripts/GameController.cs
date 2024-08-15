using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private string level1SceneName = "CenaInicial";
    [SerializeField] private string gameOverSceneName = "GameOver";
    [SerializeField] private string victorySceneName = "Victoria";
    [SerializeField] private string menuSceneName = "Menu";

    private bool gameEnded = false;

    void Start()
    {
        SceneManager.LoadScene(level1SceneName);
    }

    public void GameOver()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            SceneManager.LoadScene(gameOverSceneName);
        }
    }

    public void Victory()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            SceneManager.LoadScene(victorySceneName);
        }
    }

    public void RestartGame()
    {
        gameEnded = false;
        SceneManager.LoadScene(level1SceneName);
    }
}


