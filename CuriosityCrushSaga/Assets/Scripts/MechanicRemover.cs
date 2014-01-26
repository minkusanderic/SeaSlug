using UnityEngine;
using System.Collections;

public class MechanicRemover : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision)
	{

		if(collision.gameObject.tag == "Player")
		{
			var cont = collision.gameObject.GetComponent<PlayerController>();
			if(cont.hasDoubleJump)
			{
				cont.hasDoubleJump = false;
			}
			else
			{
				cont.hasClimb = false;
			}
		}
	}
}
