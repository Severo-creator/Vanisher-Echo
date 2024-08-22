using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }

    public GameObject spiritManager;

    [SerializeField] private string level1SceneName = "CenaInicial";
    [SerializeField] private string level2SceneName = "Fase1";
    [SerializeField] private string gameOverSceneName = "GameOver";
    [SerializeField] private string victorySceneName = "Vitoria";
    [SerializeField] private string menuSceneName = "Menu";
    [SerializeField] private string introSceneName = "Introducao";
    private List<string> fases = new List<string>();

    private bool gameEnded = false;

    public int fase;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Debug.Log("Found more than one GameController in the scene.");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        spiritManager = GameObject.Find("SpiritManager");
        level1SceneName = "CenaInicial";
        gameOverSceneName = "GameOver";
        victorySceneName = "Vitoria";
        menuSceneName = "Menu";
        level2SceneName = "Fase1";
        fases.Add(level1SceneName);
        fases.Add(level2SceneName);
    }

    public void loadGame()
    {
        SceneManager.LoadScene(introSceneName);
        fase = 0;
        spiritManager = GameObject.Find("SpiritManager");
    }

    public void StartFirstLevel()
    {
        SceneManager.LoadScene(level1SceneName);
        spiritManager = GameObject.Find("SpiritManager");
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

            fase++;
            if (fase == fases.Count)
            {
                SceneManager.LoadScene(victorySceneName);
                gameEnded = true;
            }
            else
            {
                SceneManager.LoadScene(fases[fase]);
                spiritManager = GameObject.Find("SpiritManager");
            }
        }
    }

    public void RestartGame()
    {
        gameEnded = false;
        SceneManager.LoadScene(fases[fase]);
    }
}


