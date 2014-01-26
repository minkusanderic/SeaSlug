using UnityEngine;
using System.Collections;

public class DeathReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		collision.gameObject.GetComponent<PlayerController>().Respawn();
	}
}
