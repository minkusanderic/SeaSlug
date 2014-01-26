using UnityEngine;
using System.Collections;

public class MechanicRemover : MonoBehaviour
{
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

			cont.Respawn();
		}
	}
}
