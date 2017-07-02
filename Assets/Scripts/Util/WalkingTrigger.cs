using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingTrigger : MonoBehaviour {
	public GameObject camera;
	public Vector3 camdif;
	public float dist;
	public Vector3 offset;

	void Start(){
		camdif = camera.transform.position - transform.position;
	}

	void Update () {
		transform.LookAt (camera.transform.position);
		transform.position = Vector3.Lerp(transform.position, new Vector3 (camera.transform.position.x + offset.x + (camera.transform.forward.x*dist), transform.position.y, camera.transform.position.z + offset.z + (camera.transform.forward.z*dist)), Time.deltaTime*10f);

	}
}
