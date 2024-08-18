using System.Collections.Generic;
using UnityEngine;

public class SpiritManager : MonoBehaviour
{

    private List<SpiritController> Spirits = new List<SpiritController>();

    public int contagem;

    private bool Victoria;

    void Start()
    {
        SpiritController[] children = GetComponentsInChildren<SpiritController>();

        foreach (SpiritController child in children)
        {
            Spirits.Add(child);
        }

        DisableSpirits();

        contagem = 0;
        Victoria = false;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Spirits.Count; i++)
        {
            if (contagem == i)
            {
                Spirits[i].enabled = true;
                Spirits[i].EnableCollider();
                if (Spirits[i].GetCatched())
                {
                    DisableSpirits();
                    contagem++;
                }
            }
        }
        if(contagem == Spirits.Count){
            Victoria = true;
        }
    }

    public void DisableSpirits()
    {
        for (int i = 0; i < Spirits.Count; i++)
        {
            Spirits[i].enabled = false;
            Spirits[i].DisableCollider();
        }
    }

    public bool CompletouFase(){
        return Victoria;
    }
}
