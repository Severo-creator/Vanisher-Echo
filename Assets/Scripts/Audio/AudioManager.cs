using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {get; private set; }

    private EventInstance ambienceEventInstance;

    private List<StudioEventEmitter> eventEmitters;
    private List<EventInstance> eventInstances;

    private void Awake(){
        if (instance != null){
            Debug.LogError("Found more than one Audio Manager in the scene.");
        }
        instance = this;

        eventEmitters = new List<StudioEventEmitter>();
        eventInstances = new List<EventInstance>();

    }

    private void Start(){
        //InitializeAmbience(FMODEvents.instance.ambience);
    }

    public void InitializeAmbience(EventReference ambienceEventReference){
        ambienceEventInstance = CreateInstance(ambienceEventReference);
        ambienceEventInstance.start();
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos){
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateInstance (EventReference eventReference){
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }

    private void CleanUp()
    {
        // stop and release any created instances
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
        // stop all of the event emitters, because if we don't they may hang around in other scenes
        foreach (StudioEventEmitter emitter in eventEmitters)
        {
            emitter.Stop();
        }
    }

    public StudioEventEmitter InitializeEventEmitter(EventReference eventReference, GameObject emitterGameObject)
    {
        StudioEventEmitter emitter = emitterGameObject.GetComponent<StudioEventEmitter>();
        emitter.EventReference = eventReference;
        eventEmitters.Add(emitter);
        return emitter;
    }

    private void OnDestroy()
    {
    CleanUp();
    }
}