using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class AreaEffectSonnar : MonoBehaviour
{

    public GameObject player;
    public bool Sonar;
    public Rigidbody2D rg;

    public Rigidbody2D playerrg;
    public Collider2D collider;
    public StudioEventEmitter ev;
    private EventInstance eventInstance;

    public GameObject TopCheck;
    public GameObject BopCheck;

    public bool grounded;
    public bool fall;
    public LayerMask layerMask;

    private int direction;

    public Transform areaAudicao;
    // Start is called before the first frame update
    void Start()
    {
        grounded = false;
        fall = false;
        rg = GetComponent<Rigidbody2D>();
        Sonar = false;
        collider = GetComponent<Collider2D>();
        collider.enabled = false;
        EventInstance eventInstance = AudioManager.instance.CreateInstance(FMODEvents.instance.Passos);
        ev = GetComponent<StudioEventEmitter>();
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {

        grounded = Physics2D.Linecast(TopCheck.transform.position, BopCheck.transform.position, layerMask);
        if (!grounded && Sonar)
        {         
            ev.Stop();
            //eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        if (!Sonar) transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        if (playerrg.velocity.x > 0)
        {
            direction = 1;
            areaAudicao.rotation = Quaternion.Euler(0, 0,0);
        }
        else if (playerrg.velocity.x < 0)
        {
            direction = -1;
            areaAudicao.rotation = Quaternion.Euler(0, 180,0);
        }

    }

    public void groundCheck()
    {
        Sonar = true;
        collider.enabled = true;
        ev.Play();
        PLAYBACK_STATE playbackState;
        eventInstance.getPlaybackState(out playbackState);
        rg.velocity = new Vector2(10 * direction, rg.velocity.y);
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(1.50f);
        rg.velocity = new Vector2(0, rg.velocity.y);
        ev.Stop();
        eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        fall = false;
        collider.enabled = false;
        Sonar = false;

    }

}
