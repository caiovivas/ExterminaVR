using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	void Start(){
		GameObject[] allGos = GameObject.FindObjectsOfType < GameObject > ();
		foreach (GameObject g in allGos) {
			if (g.GetComponent<DontDestroy> () != null)
				Destroy (g);
		}
	}

	public void StartGame(){
		SceneManager.LoadScene ("IC_Andar_1");
	}
}
