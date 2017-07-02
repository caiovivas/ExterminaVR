using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAPCMessage : MonoBehaviour {
	public GameObject[] pcs;
	public Material mat;
	public GameObject light;
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			foreach (GameObject p in pcs) {
				p.GetComponent<MeshRenderer> ().material = mat;
				p.GetComponent<Gif> ().enabled = true;
			}
			light.SetActive (true);
			Destroy (gameObject);
		}
	}
}
