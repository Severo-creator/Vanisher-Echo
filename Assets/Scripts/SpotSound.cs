using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class SpotSound : MonoBehaviour
{


    public StudioEventEmitter ev;

    // Start is called before the first frame update
    void Start()
    {
        ev = GetComponent<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D c2D){
        
        if(c2D.gameObject.CompareTag("Player")){
            //Stop Event
            ev.Stop();
            Debug.Log("stop");
        }
        else if(c2D.gameObject.CompareTag("Sonar")){
            //Play de evento
            //AudioManager.PlayOneShot(FMODEvents.WindSound);
            ev.Play();         
            Debug.Log("play");
        } 

    }

}
