using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isGrounded;
    public Rigidbody2D rg;
    public LayerMask groundLayer;
    public GameObject groundCheck;

    
    public float jumpForce;
    public float velX;
    public int velY;
    public bool grounded;
    public bool AirJump;
    public LayerMask layerMask;
    
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        grounded = false;
        AirJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        


        bool jumpInput = Input.GetButtonDown("Jump");

        grounded = Physics2D.Linecast(transform.position, groundCheck.transform.position, layerMask);
        if(grounded)AirJump=true;

        rg.velocity = new Vector2(Input.GetAxis("Horizontal")*velX, rg.velocity.y);
        
        if (jumpInput && (grounded || AirJump))
        {
            if(!grounded)AirJump=false;
            rg.velocity = new Vector2(rg.velocity.x, jumpForce);
        }
    }



}
