using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public List<Dialoguemark> DialogueMasks = new List<Dialoguemark>();

    private int marcaatual = 0;

    // Start is called before the first frame update
    void Start()
    {
        Dialoguemark[] children = GetComponentsInChildren<Dialoguemark>();

        foreach (Dialoguemark child in children)
        {
            DialogueMasks.Add(child);
        }
        
        AudioManager.instance.InitializeDialogue(FMODEvents.instance.Dialogo);
        AudioManager.instance.SetDialogueParameter(0);
    }

    // Update is called once per frame
    void Update()
    {
        int aux = 0;
        foreach(Dialoguemark child in DialogueMasks){
            aux++;
            if(child.InMark()){
                AudioManager.instance.SetDialogueParameter(aux);
                if( marcaatual != aux){
                    AudioManager.instance.ResetDialogueTrack();
                }
                if(child.IstheFist()){
                    AudioManager.instance.FrasesSoltasDialogue();
                }
            }
        }        
    }
}
