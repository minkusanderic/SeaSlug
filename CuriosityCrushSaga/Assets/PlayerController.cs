using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10.0f;
	public float jump_strength = 10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var value = Input.GetAxis("Horizontal");
		//var a = GetComponent(Rigidbody);
		var body = gameObject.GetComponent<Rigidbody2D>();
		//body.AddForce(Vector2.right * value); 
		body.velocity = new Vector2(value * speed, body.velocity.y);
		//body.velocity += Vector2.right * value * speed;

		if( Input.GetButtonDown("Jump") )
		{
			body.velocity = new Vector2(body.velocity.x, jump_strength);
		}
	}
}
