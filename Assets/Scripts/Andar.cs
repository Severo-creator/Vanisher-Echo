using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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

        if (grounded)
        {
            AirJump = true;

            if (falling)
            {
                falling = false;
                AudioManager.instance.PlayOneShot(FMODEvents.instance.ImpactSound, transform.position);
                Debug.Log("impact sound");
            }
            animator.SetBool("isJumping", false);
        }
        else
        {
            AudioManager.instance.stopWalk();
            falling = true;
            animator.SetBool("isJumping", true);
        }
        

        if (jumpInput && (grounded || AirJump))
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.Jump, transform.position);
            if (!grounded)
            {
                AirJump = false;
                animator.Play("Jumping", -1, 0f); //Restart Jumping animation
            }
            rg.velocity = new Vector2(rg.velocity.x, jumpForce);
            animator.SetBool("isJumping", true);
        }
    }

    private void FixedUpdate()
    {
        
        rg.velocity = new Vector2(Input.GetAxis("Horizontal") * velX, rg.velocity.y);


        if(rg.velocity.x != 0){

            if(!AudioManager.instance.isWalking() && grounded){
                AudioManager.instance.InitializeStepSound();
            }
        }else{
            AudioManager.instance.stopWalk();
        }

        if (Input.GetAxis("Horizontal") > 0 && !facingRight)
        {
            Flip();
        }
        if (Input.GetAxis("Horizontal") < 0 && facingRight)
        {
            Flip();
        }
           
        // Handling Animations
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
