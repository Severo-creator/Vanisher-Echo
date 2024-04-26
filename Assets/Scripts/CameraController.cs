using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //private void Awake() {
    //   
    //}

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x,
            transform.position.y, transform.position.z);
    }

    //private void FixedUpdate() {
    //    
    //}

    //private void OnDestroy() {
    //    Destroy(this);
    //}
}
