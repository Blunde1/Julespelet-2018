using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public Rigidbody2D rb;
    public float force;// = 100f;
    public float jump;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    private int numJumps = 0;
    private int maxJumps = 2;
    private int jumpFrameCount = 0;
    private int maxFrameCount = 15;

	// Use this for initialization
	void Start () {
        rb.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        //float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, 0);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb.AddForce(movement * force);

        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (onGround)
        {
            numJumps = 0;
            jumpFrameCount = 0;
        }else
        {
            jumpFrameCount += 1; // count frames
        }
        
        if (Input.GetKey("up")  && (numJumps < maxJumps) && ( onGround  || jumpFrameCount > maxFrameCount) )
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y+ jump); // jump
            numJumps += 1; // count jumps in air
            jumpFrameCount = 0; // reset frame counter
        }

	}
 
}
