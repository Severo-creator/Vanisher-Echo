using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string gameLevel;
    [SerializeField] private GameObject painelMenu;
    [SerializeField] private GameObject painelOPTS;
    public void Jogar()
    {
        GameController.instance.loadGame();
    }

    public void AbrirOpts()
    {
        painelMenu.SetActive(false);
        painelOPTS.SetActive(true);
    }

    public void FecharOpts()
    {
        painelMenu.SetActive(true);
        painelOPTS.SetActive(false);
    }

    public void Sairjogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
