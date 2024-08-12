using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class SpotSound : MonoBehaviour
{

    public bool Catched;
    public StudioEventEmitter ev;

    // Start is called before the first frame update
    void Start()
    {
        ev = GetComponent<StudioEventEmitter>();
        Catched = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D c2D){
        
        if(c2D.CompareTag("Player")){
            //Stop Event
            ev.Stop();
            //Debug.Log("stop");
            Catched = true;
            AudioManager.instance.PlayOneShot(FMODEvents.instance.GhostCatch, transform.position);
        }
        else if(c2D.CompareTag("Sonar")){
            //Play de evento
            ev.Play();         
            Debug.Log("play");
        } 

    }

    public bool GetCatched(){
        return Catched;
    }

}
