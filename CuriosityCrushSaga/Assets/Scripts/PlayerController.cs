using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public bool hasDoubleJump;
	public bool hasClimb;


	public float runningSpeed = 10.0f;
	public float climbingSpeed = 2.0f;

	public float jump_strength = 10.0f;
	public float jumpSpeedRatio = .8f;

	public float maxGlideSpeed = 10.0f;


	private enum STATES {
		STANDING,
		JUMPING,
		DOUBLEJUMP,
		CLIMBING,
		RUNNING 
	};

	private STATES currentState = STATES.JUMPING;
	private GameObject currentAttached = null;

	private Rigidbody2D body;
	// Use this for initialization
	void Start () {
		body = gameObject.GetComponent<Rigidbody2D>();
        Globals.Positions[0] = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //var value = Input.GetAxis("Horizontal");
		//var a = GetComponent(Rigidbody);
		//var body = gameObject.GetComponent<Rigidbody2D>();
		//body.AddForce(Vector2.right * value); 
		//body.velocity = new Vector2(value * speed, body.velocity.y);
		//body.velocity += Vector2.right * value * speed;

        if (Vector3.Distance(transform.position, Globals.Positions[0]) > Globals.FollowDeadZone)
        {
            Globals.Positions[1] = Globals.Positions[0];
            Globals.Positions[0] = transform.position;
        }

		handleStates();
	}

	private void handleStates()
	{
		var horizontal = Input.GetAxis("Horizontal");
		var vertical = Input.GetAxis("Vertical");

		switch(currentState)
		{
		case STATES.STANDING:
			body.gravityScale = 1.0f;
			body.angularVelocity = 0.0f;
			if( Input.GetButtonDown("Jump") )
			{
				body.velocity = new Vector2(body.velocity.x, jump_strength);
				switchTo(STATES.JUMPING);
			}else if(horizontal != 0.0f)
			{
				body.velocity = new Vector2(horizontal * runningSpeed, body.velocity.y);
				switchTo (STATES.RUNNING);
			}

			break;
		case STATES.JUMPING:
			body.gravityScale = 1.0f;

			body.velocity = new Vector2(horizontal * runningSpeed * jumpSpeedRatio, Mathf.Max(body.velocity.y, -maxGlideSpeed));
			if( hasDoubleJump && Input.GetButtonDown("Jump") )
			{
				body.velocity = new Vector2(body.velocity.x, jump_strength);
				switchTo(STATES.DOUBLEJUMP);
			}
			break;
		case STATES.DOUBLEJUMP:
			body.gravityScale = 1.0f;
			
			body.velocity = new Vector2(horizontal * runningSpeed * jumpSpeedRatio, Mathf.Max(body.velocity.y, -maxGlideSpeed));
			break;
		case STATES.RUNNING:
			body.gravityScale = 1.0f;
			if(horizontal != 0.0f)
			{
				body.velocity = new Vector2(horizontal * runningSpeed, body.velocity.y);
			}else
			{
				switchTo(STATES.STANDING);
			}
			if( Input.GetButtonDown("Jump") )
			{
				body.velocity = new Vector2(body.velocity.x, jump_strength);
				switchTo(STATES.JUMPING);
			}
			break;
		case STATES.CLIMBING:
			body.gravityScale = 0.0f;
			body.velocity = new Vector2(0.0f, vertical * climbingSpeed);
			if( Input.GetButtonDown("Jump") ) {
				body.velocity = new Vector2(horizontal, jump_strength * .5f);
				switchTo(STATES.JUMPING);
			}
			break;
		}
		body.velocity = new Vector2(body.velocity.x, Mathf.Max(body.velocity.y, -maxGlideSpeed));
	}

	void OnCollisionEnter2D(Collision2D collision) {
	
		switch(currentState)
		{
		case STATES.STANDING:
			break;
		case STATES.JUMPING:
		case STATES.DOUBLEJUMP:

			if(hasClimb && collision.gameObject.tag == "Climable")
			{
				switchTo(STATES.CLIMBING);
				currentAttached = collision.gameObject;
			}
			else
			{
				switchTo(STATES.STANDING);
			}
			break;
		case STATES.RUNNING:
			if(collision.gameObject.tag == "Climable")
			{
				switchTo(STATES.CLIMBING);

			}
			break;
		case STATES.CLIMBING:
			switchTo(STATES.JUMPING);
			break;
		
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		switch(currentState)
		{
		case STATES.STANDING:
			break;
		case STATES.JUMPING:
		case STATES.DOUBLEJUMP:
			break;
		case STATES.RUNNING:
			if(collision.gameObject.tag == "Climable")
			{
				switchTo(STATES.CLIMBING);
				
			}
			break;
		case STATES.CLIMBING:
			if(collision.gameObject == currentAttached)
			{
				switchTo(STATES.JUMPING);
				currentAttached = null;
			}
			break;
			
		}
	}

	 void switchTo(STATES state)
	{
		currentState = state;
	}
}
