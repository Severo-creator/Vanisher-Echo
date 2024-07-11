using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SonarLightEffect : MonoBehaviour
{

    
    public Renderer rendererComponent;
    public Light2D Light2D;

    public float startValue = 0f; // Valor inicial
    public float endValue = 20f; // Valor final
    public float duration = 0.50f; // Duração da transição
    
    private float timer = 0f; // Cronômetro para controlar a transição


    // Start is called before the first frame update
    void Start()
    {
        Light2D = GetComponent<Light2D>();
        Light2D.pointLightInnerRadius = 0f;
        Light2D.pointLightOuterRadius = 0f;
    }

    // Update is called once per frame


    public void Sonar(){
        StartCoroutine(InterpolateValues());
        return;
    }

    IEnumerator InterpolateValues()
    {
        // Loop até a transição estar completa
        while (timer < duration)
        {

            timer += Time.deltaTime;

            // Calcula o valor atual suavemente entre startValue e endValue
            Light2D.pointLightInnerRadius = Mathf.Lerp(startValue, endValue, timer / duration);
            Light2D.pointLightOuterRadius = Light2D.pointLightInnerRadius;

            // Exibe o valor atual
            //Debug.Log("Current Value: " + Light2D.pointLightInnerRadius);

            // Aguarda o próximo quadro
            yield return null;
        }

        // Transição concluída
        Debug.Log("Transition Complete");
        timer = 0f;
    }

    public void TurnOFF(){
        Light2D.pointLightInnerRadius = 0f;
        Light2D.pointLightOuterRadius = 0f;
        return;
    }
}
