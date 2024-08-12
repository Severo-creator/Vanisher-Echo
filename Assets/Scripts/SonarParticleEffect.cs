using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SonarParticleEffect : MonoBehaviour
{


    public ParticleSystem ps;
    public bool Pause;
    public GameObject Lightef;
    
    public GameObject groundedSonar;
    public SonarLightEffect SpotLight;
    public AreaEffectSonnar areaEffect;
    
    public LayerMask layerMask;

     public float startValue = 0f; // Valor inicial
    public float endValue = 10f; // Valor final
    public float duration = 0.50f; // Duração da transição
    
    private float timer = 0f; 

    public Animator animator;
   
    void Start()
    {
        Pause = false;
        ps = GetComponent<ParticleSystem>();
        animator = GetComponentInParent<Animator>();
    }

  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T) && Pause == false){
            animator.Play("search");
            Lightef.transform.position = transform.position;
            ps.Play();
            SpotLight.Sonar();
            PlataformScan();
          
            AudioManager.instance.PlayOneShot(FMODEvents.instance.Sonar, transform.position);
            StartCoroutine(MyCoroutine());
          
        }

            

    }

    public void PlataformScan(){
        areaEffect.groundCheck();
    }



    IEnumerator MyCoroutine()
    {
        Pause = true;
        yield return new WaitForSeconds(0.87f);
        ps.Stop();
        StartCoroutine(Light());
    }

    IEnumerator  Light(){
        yield return new WaitForSeconds(2f);
        SpotLight.TurnOFF();
        Pause = false;
    }

}
