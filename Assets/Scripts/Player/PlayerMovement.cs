using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float movementSpeed;
	public bool walking;
	public GameObject camera;
	public Light flashlight;
	public string key;
	public int tickets;
	public TextMesh ticketCounter; 

	void Start(){
		DontDestroyOnLoad (gameObject);
	}

	public void SetWalkingState(bool state){
		walking = state;
	}

	public void SetFlashlight(){
		flashlight.enabled = !flashlight.enabled;
	}

	void Update(){
		if (Input.GetButton ("Fire1")) {
			walking = !walking;
		}

		if(walking){
			transform.position += new Vector3(camera.transform.forward.x,0f,camera.transform.forward.z) * Time.deltaTime;
		}
	}

	public void AddTicket(){
		tickets++;
		ticketCounter.text = tickets.ToString ();
	}
}
