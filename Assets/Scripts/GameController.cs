using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance {get; private set; }

    public GameObject spiritManager;

    [SerializeField] private string level1SceneName = "CenaInicial";
    [SerializeField] private string level2SceneName = "Fase1";
    [SerializeField] private string gameOverSceneName = "GameOver";
    [SerializeField] private string victorySceneName = "Vitoria";
    [SerializeField] private string menuSceneName = "Menu";
    private List<string> fases = new List<string>();

    private bool gameEnded = false;

    public int fase;

    private void Awake(){
        if (instance == null){
            DontDestroyOnLoad(gameObject);
            instance = this;
        }else{
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

    public void loadGame(){
        SceneManager.LoadScene(level1SceneName);
        fase = 0;
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
            if(spiritManager != null){
                fase++;
                if(fase == fases.Count){
                    SceneManager.LoadScene(victorySceneName);
                    gameEnded = true;
                }else{
                    SceneManager.LoadScene(fases[fase]);
                }
                
            }else{
                SceneManager.LoadScene(victorySceneName);
            }
        }
    }

    public void RestartGame()
    {
        gameEnded = false;
        SceneManager.LoadScene(fases[fase]);
    }
}

