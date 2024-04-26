using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpHeight;
    public float velocity;

    bool grounded = false;
    public GameObject groundCheck;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = new Vector2(Input.GetAxis("Horizontal")*velocity, rb.velocity.y);

        /*Pulo JETPACK
         * if (Input.GetAxis("Jump") > 0) {
            rb.AddForce(new Vector2(0, jumpHeight));
        }*/

        grounded = Physics2D.Linecast(transform.position, 
            groundCheck.transform.position, layerMask);

        if (Input.GetAxis("Jump") > 0 && grounded) {
            rb.AddForce(new Vector2(0, jumpHeight));
        }

        /*if (Input.GetKeyDown(KeyCode.Space)) {

        }*/
    }
}
