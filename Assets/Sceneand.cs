using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneand : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if (this.name.Equals("BordaBaixo"))
        {
            if (collision.gameObject.name.Equals("Player"))
            {
                SceneManager.LoadScene("Gameover");
            }
        }
        if (this.name.Equals("BordaDireita"))
        {
            if (collision.gameObject.name.Equals("Player"))
            {
                SceneManager.LoadScene("Vitoria");
            }
        }
        
    }
}
