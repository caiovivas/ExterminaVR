using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetor : MonoBehaviour {

	public GameObject projectorObjects;

	public void OnActivate(){
		if (Vector3.Distance (GameManager.player.transform.position, transform.position) > 2f)
			return;
		projectorObjects.SetActive (true);
	}
}
