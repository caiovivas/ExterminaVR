using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVision : MonoBehaviour {

	public Transform eye;
	public LayerMask visionLayer;
	public static PlayerVision vision;

	public static bool macbonnerInVision;

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

	public bool IsInPlayerSight(Transform f){
		RaycastHit hit;
		if (Physics.Raycast (eye.position, f.transform.position - eye.position, out hit, 100f, visionLayer)) {
			return (hit.transform == f);
		}
		return false;
	}

	void Update(){
		RaycastHit hit;
		if (Physics.Raycast (eye.position, GameManager.macbonnerObject.transform.position, out hit, 100f, visionLayer)) {
			if (hit.transform.tag == "MacBonner") {
				macbonnerInVision = true;
			} else
				macbonnerInVision = false;
		}
	}
}
