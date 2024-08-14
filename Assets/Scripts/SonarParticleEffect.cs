using System.Collections;
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
        if (Input.GetKeyDown(KeyCode.T) && Pause == false)
        {
            if (animator.GetFloat("xVelocity") == 0)
            {
                animator.Play("search");
            }
            Lightef.transform.position = transform.position;
            ps.Play();
            SpotLight.Sonar();
            PlataformScan();

            AudioManager.instance.PlayOneShot(FMODEvents.instance.Sonar, transform.position);
            StartCoroutine(MyCoroutine());

        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("search") && animator.GetFloat("xVelocity") != 0)
        {
            animator.Play("Movement");
        }
    }

    public void PlataformScan()
    {
        areaEffect.groundCheck();
    }

    IEnumerator MyCoroutine()
    {
        Pause = true;
        yield return new WaitForSeconds(0.87f);
        ps.Stop();
        StartCoroutine(Light());
    }

    IEnumerator Light()
    {
        yield return new WaitForSeconds(2f);
        SpotLight.TurnOFF();
        Pause = false;
    }
}
