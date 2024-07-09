using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isGrounded;
    public Rigidbody2D rg;
    public LayerMask groundLayer;
    public GameObject groundCheck;
    Animator animator;


    public float jumpForce;
    public float velX;
    public int velY;
    public bool grounded;
    public bool AirJump;
    public LayerMask layerMask;
    bool falling = false;
    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        grounded = false;
        AirJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        bool jumpInput = Input.GetButtonDown("Jump");

        grounded = Physics2D.Linecast(transform.position, groundCheck.transform.position, layerMask);
        
        if (!grounded)
        {
            falling = true;
        }
        if (grounded && falling)
        {
            falling = false;
            Debug.Log("impact sound");
            animator.SetBool("isJumping", false);
        }

        if (grounded) AirJump = true;

        if (jumpInput && (grounded || AirJump))
        {
            if (!grounded) AirJump = false;
            rg.velocity = new Vector2(rg.velocity.x, jumpForce);
            animator.SetBool("isJumping", true);
        }
    }

    private void FixedUpdate()
    {
        rg.velocity = new Vector2(Input.GetAxis("Horizontal") * velX, rg.velocity.y);
        if (Input.GetAxis("Horizontal") > 0 && !facingRight)
        {
            Flip();
        }
        if (Input.GetAxis("Horizontal") < 0 && facingRight)
        {
            Flip();
        }
           
        animator.SetFloat("xVelocity", Math.Abs(rg.velocity.x));
        animator.SetFloat("yVelocity", rg.velocity.y);
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

}
