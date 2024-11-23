using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dialoguemark : MonoBehaviour
{
    
    private bool primeiroEncontro = true;

    private bool ishere = false;


    Collider2D collider;

    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            ishere = true;
            
        }
    }

     private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ishere = true;
            Debug.Log("O player está dentro do trigger!");
        }
    }

    public bool InMark(){
        return ishere;
    }

    public bool IstheFist(){
        return primeiroEncontro;
    }


    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            primeiroEncontro = false;
            ishere = false;
        }
    }

}
