using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverMenu : MonoBehaviour
{
    [SerializeField] private string gameLevel;
    [SerializeField] private string menuPrincipal;
    public void Botao_Reiniciar()
    {
        SceneManager.LoadScene(gameLevel);
    }

    public void Botao_MenuPrincipal()
    {
        SceneManager.LoadScene(menuPrincipal);
    }
}
