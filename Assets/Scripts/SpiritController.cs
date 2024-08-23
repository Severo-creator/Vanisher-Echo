using FMODUnity;
using UnityEngine;

public class SpiritController : MonoBehaviour
{
    public bool Catched;
    public StudioEventEmitter ev;
    public Animator animator;
    public BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        ev = GetComponent<StudioEventEmitter>();
        Catched = false;
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
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
            collider.enabled = false;
            animator.SetBool("isSinging", false);
        }
        else if (c2D.CompareTag("Sonar"))
        {
            //Play de evento
            ev.Play();
            animator.SetBool("isSinging", true);
        }

    }

    public bool GetCatched()
    {
        return Catched;
    }

    public void DisableCollider()
    {
        collider.enabled = false;
    }

    public void EnableCollider()
    {
        collider.enabled = true;
    }

}
