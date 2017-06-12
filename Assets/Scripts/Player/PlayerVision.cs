using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVision : MonoBehaviour {

	public Transform eye;
	public LayerMask visionLayer;
	public static PlayerVision vision;

	void Start(){
		vision = this;
	}

	public Transform GetObjectInPlayerSight(){
		RaycastHit hit;
		if (Physics.Raycast (eye.position, eye.forward, out hit, 100f, visionLayer)) {
			return hit.transform;
		}
		return null;
	}
}
