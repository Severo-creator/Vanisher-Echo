using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritManager : MonoBehaviour
{
    
    private List<SpotSound> Spirits = new List<SpotSound>();

    public int contagem;
    
    void Start()
    {
        SpotSound[] children = GetComponentsInChildren<SpotSound>();

        foreach (SpotSound child in children)
        {
            Spirits.Add(child);
        }

        DisableSpirits();

        contagem = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i =0; i < Spirits.Count; i++){
            if(contagem == i){
                DisableSpirits();
                Spirits[i].enabled = true;
                if(Spirits[i].GetCatched()){
                 contagem++;
                }
            }
            
        }
        Debug.Log(contagem);
    }

    public void DisableSpirits(){
        for(int i =0; i < Spirits.Count; i++){
            Spirits[i].enabled = false;
        }

    }
}
