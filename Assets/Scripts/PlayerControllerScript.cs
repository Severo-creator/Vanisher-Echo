using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public Sprite[] spriteVec;

    public float velX;
    public float velY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal")*velX, 
            Input.GetAxis("Vertical")*velY);

        if (Input.GetAxis("Horizontal") > 0) {
            sr.sprite = spriteVec[1];
        }

        if (Input.GetAxis("Horizontal") < 0) {
            sr.sprite = spriteVec[3];
        }

        if (Input.GetAxis("Vertical") < 0) {
            sr.sprite = spriteVec[0];
        }

        if (Input.GetAxis("Vertical") > 0) {
            sr.sprite = spriteVec[2];
        }

        //sr.sprite

        //rb.AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

        /*if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("OLA");
        }*/

        /* if (Input.GetAxis("Horizontal") != 0)
        {
            float x = Input.GetAxis("Horizontal");
            this.transform.position = new Vector3(transform.position.x+x, transform.position.y,
                transform.position.z);
            //Debug.Log(Input.GetAxis("Horizontal")+"");
        }

        Input.GetAxis("Vertical");*/

    }
}
