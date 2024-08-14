using FMODUnity;
using System.Collections;
using UnityEngine;

public class SpiritController : MonoBehaviour
{
    public bool Catched;
    public StudioEventEmitter ev;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        ev = GetComponent<StudioEventEmitter>();
        Catched = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D c2D)
    {

        if (c2D.CompareTag("Player"))
        {
            //Stop Event
            ev.Stop();
            //Debug.Log("stop");
            Catched = true;
            AudioManager.instance.PlayOneShot(FMODEvents.instance.GhostCatch, transform.position);
        }
        else if (c2D.CompareTag("Sonar"))
        {
            //Play de evento
            ev.Play();
            animator.SetBool("isSinging", true);
            StartCoroutine(StopSingingAfterTime(1.0f));
            Debug.Log("play");
        }
    }
    IEnumerator StopSingingAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool("isSinging", false);
        ev.Stop();
    }

    public bool GetCatched()
    {
        return Catched;
    }

}
