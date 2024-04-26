using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AreaEffectSonnar : MonoBehaviour
{

    public GameObject player;
    public bool Sonar;
    public Rigidbody2D rg;
    public  Collider2D collider;
    public StudioEventEmitter ev;

    public GameObject TopCheck;
    public GameObject BopCheck;

    public bool grounded;
    public bool fall;
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        grounded = false;
        fall = false;
        rg = GetComponent<Rigidbody2D>();
        Sonar = false;
        collider = GetComponent<Collider2D>();
        collider.enabled = false;
        ev = GetComponent<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        
        grounded = Physics2D.Linecast(TopCheck.transform.position, BopCheck.transform.position, layerMask);
        if(!grounded && !fall){
            Debug.Log("SEM CHAO!");
            ev.Stop();
            fall = true;
        }

       if(!Sonar) transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }

    public void groundCheck(){
        Sonar = true;
        collider.enabled = true;
        ev.Play();
        rg.velocity = new Vector2(10, rg.velocity.y);
        StartCoroutine(MyCoroutine());
    }

     IEnumerator MyCoroutine()
    {
        

        yield return new WaitForSeconds(0.87f);
        rg.velocity = new Vector2(0, rg.velocity.y);
        ev.Stop();
        fall = false;
        collider.enabled = false;
        Sonar = false;

    }

}
