using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	public float zoomLevel = 10.0f;
	public float zoomScale = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var pos = target.transform.position;
		var vel = target.GetComponent<Rigidbody2D>().velocity;
		gameObject.transform.position = new Vector3(pos.x, pos.y, gameObject.transform.position.z);
		var camera = gameObject.GetComponent<Camera>();

		//camera.orthographicSize = zoomLevel + zoomScale * vel.magnitude;


	}
}
