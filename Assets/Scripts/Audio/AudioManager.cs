using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {get; private set; }

    private EventInstance ambienceEventInstance;

    private EventInstance stepEventInstance;

    private EventInstance DialogueEventInstance;

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
        stepEventInstance = CreateInstance(FMODEvents.instance.Passos);
        InitializeAmbience(FMODEvents.instance.ambience);
        eventInstances.Add(stepEventInstance);
        eventInstances.Add(ambienceEventInstance);


    }

    public void InitializeAmbience(EventReference ambienceEventReference){
        ambienceEventInstance = CreateInstance(ambienceEventReference);
        ambienceEventInstance.start();
    }

    public void InitializeDialogue(EventReference EventReference){
        DialogueEventInstance = CreateInstance(EventReference);
        DialogueEventInstance.start();
    }

    public void InitializeStepSound(){
       stepEventInstance.start();
    }

    public void stopWalk(){
        
        if (stepEventInstance.isValid()){
            stepEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            //stepEventInstance.release();
        }
    }

    public bool isWalking(){
        PLAYBACK_STATE playbackState;
        stepEventInstance.getPlaybackState(out playbackState);
        return playbackState == PLAYBACK_STATE.PLAYING;
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
