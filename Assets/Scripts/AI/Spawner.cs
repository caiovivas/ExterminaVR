using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public float minimumPlayerDistance;
	public float maximumPlayerDistance;
	public static float cooldown;

	void Update(){
		float distance = Vector3.Distance (GameManager.player.transform.position, transform.position);

		if (!Macbonner.active && distance > minimumPlayerDistance && distance < maximumPlayerDistance && cooldown <= 0 && !PlayerVision.vision.IsInPlayerSight(transform)) {
				GameManager.macbonnerObject.GetComponent<Macbonner> ().Spawn (transform.position);
		}
	}
}
