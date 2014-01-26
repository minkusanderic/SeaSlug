using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public GameObject bg1;
	public GameObject bg2;
	public GameObject bg3;

	public float bg1Scale;
	public float bg2Scale;
	public float bg3Scale;

	public GameObject camera;

	public float Center;


	// Use this for initialization
	void Start () {
		Center = camera.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		//bg1Scale * (Camera.main.transform.position.x - Center) + Camera.main.transform.position.x
		bg1.transform.position = new Vector3(camera.transform.position.x + bg1Scale * (camera.transform.position.x - Center), bg1.transform.position.y, bg1.transform.position.z);
		bg2.transform.position = new Vector3(camera.transform.position.x, bg2.transform.position.y, bg2.transform.position.z);
		bg3.transform.position = new Vector3(camera.transform.position.x, bg3.transform.position.y, bg3.transform.position.z);
	}
}
