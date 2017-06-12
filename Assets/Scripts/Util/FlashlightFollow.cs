using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightFollow : MonoBehaviour {
	Transform cameraT;
	public float followSpeed;
	public float rotationSpeed;
	void Start(){
		cameraT = Camera.main.transform;
	}
	void Update () {
		transform.position = Vector3.Lerp (transform.position, cameraT.position, Time.deltaTime * followSpeed);
		transform.rotation = Quaternion.Lerp (transform.rotation, cameraT.rotation, Time.deltaTime * rotationSpeed);
	}
}
