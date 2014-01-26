using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	
	// Update is called once per frame
	void Update () {
		var pos = target.transform.position;
		gameObject.transform.position = new Vector3(pos.x, pos.y, gameObject.transform.position.z);
	}
}
