using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private string menuSceneName = "Menu";
    [SerializeField] private string firstLevelSceneName = "CenaInicial";

    public void StartGame()
    {
        GameController.instance.StartFirstLevel();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
