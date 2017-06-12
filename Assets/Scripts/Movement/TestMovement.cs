using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour {
	public CharacterController controller;
	public float speed;
	public float rotateSpeed;
	public GameObject flashLight;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		controller.SimpleMove (transform.forward* Input.GetAxis("Vertical") * Time.deltaTime * speed);
		transform.RotateAround (transform.position, transform.up, Input.GetAxis("Horizontal")*Time.deltaTime*rotateSpeed);

		if (Input.GetKeyDown (KeyCode.F))
			flashLight.SetActive (!flashLight.activeInHierarchy);
	}
}
