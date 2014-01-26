using UnityEngine;
using System.Collections;

public class MechanicRemover : MonoBehaviour
{
    public GameObject KillMeFirst;
    public GameObject KillMeSecond;

	void OnTriggerEnter2D(Collider2D collision)
	{

		if(collision.gameObject.tag == "Player")
		{
			var cont = collision.gameObject.GetComponent<PlayerController>();
			if(cont.hasDoubleJump)
			{
				cont.hasDoubleJump = false;
                Destroy(KillMeFirst);
			}
            else if(cont.hasDoubleJump)
			{
				cont.hasClimb = false;
                Destroy(KillMeSecond);
			}
            else
            {
                Application.LoadLevel("EndScene");
            }

			cont.Respawn();
		}
	}
}
