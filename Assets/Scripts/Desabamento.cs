using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desabamento : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.CompareTag("Player")){
            AudioManager.instance.PlayOneShot(FMODEvents.instance.Desabamento, transform.position);
        }
    }
}
