using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{

    [field: Header("Ambience")]

    [field: SerializeField] public EventReference ambience {get; private set; }

    [field: Header("SFX")]

    [field: SerializeField] public EventReference Sonar {get; private set; }

    [field: SerializeField] public EventReference WindSound {get; private set; }

    [field: SerializeField] public EventReference Passos {get; private set; }

    [field: SerializeField] public EventReference Jump {get; private set; }

    [field: SerializeField] public EventReference ImpactSound {get; private set; }

    [field: SerializeField] public EventReference Desabamento {get; private set; }

    [field: SerializeField] public EventReference GhostCatch {get; private set; }

    [field: Header("Dialogue")]

    [field: SerializeField] public EventReference Dialogo {get; private set; }

    public static FMODEvents instance {get; private set; }

    private void Awake(){
        if (instance != null){
            Debug.LogError("Found more than one Fmod Event in the scene.");
        }
        instance = this;
    }
}
