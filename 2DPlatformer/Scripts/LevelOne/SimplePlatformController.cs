using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformController : MonoBehaviour 
{
	[HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;

    // Movement
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;
	[HideInInspector] public bool grounded = false;
    private float horizontalAxis;

    // Components
	private Animator anim;
	private Rigidbody2D rb2d;


	protected void Start()
    {
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        // Jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }

    protected void FixedUpdate()
	{
	    horizontalAxis = Input.GetAxis("Horizontal");

        // Speed of the animation
		anim.SetFloat ("Speed", Mathf.Abs(horizontalAxis));

        // When character speed is less than max speed.
		if (horizontalAxis * rb2d.velocity.x < maxSpeed)
        {
            // Increase velocity
            rb2d.AddForce(Vector2.right * horizontalAxis * moveForce);
		}

        // When character speed is greater than max speed
		if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            // Cap velocity
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		}

        if(horizontalAxis > 0 && !facingRight)
        {
            Flip();
        }
        else if(horizontalAxis < 0 && facingRight)
        {
            Flip();
        }

        if(jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0.0f, jumpForce));
            jump = false;
        }
			
	}

    // Turning animation
	void Flip()
	{
        // Algorithm:
        // 1) Flip facingRight's value to it's opposite
        // 2) Change the transform's model to face the opposite:
        //     1) Store the current transform in a new variable
        //     2) Flip new variable's x position
        //     3) Set the current transform to the new transform

		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
