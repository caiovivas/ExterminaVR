using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	public float speed;

	void Update () {
		transform.LookAt (GameManager.player.transform.position);
		transform.position += transform.forward * Time.deltaTime * speed;
	}
}
