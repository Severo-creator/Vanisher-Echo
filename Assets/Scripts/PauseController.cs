using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseCanvas;
    [SerializeField] private string gameLevel;
    [SerializeField] private GameObject painelPause;
    [SerializeField] private GameObject painelOPTS;

    public void AbrirOpts()
    {
        painelPause.SetActive(false);
        painelOPTS.SetActive(true);
    }

    public void FecharOpts()
    {
        painelPause.SetActive(true);
        painelOPTS.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene(gameLevel);
    }
    public void Pause()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    public void Return()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(!pauseCanvas.activeSelf)
            {
                Pause();
            }
            else
            {
                Return();
            }
        }
    }
}
