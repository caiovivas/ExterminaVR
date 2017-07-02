using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour {
	public Texture2D[] keyDigits;
	public string keyGivenOnSolve;
	public Key[] keys;
	public AudioClip successSound;

	public void OnChange(){
		foreach (Key k in keys) {
			if (!k.right)
				return;
		}
		GameManager.player.GetComponent<PlayerMovement> ().key = keyGivenOnSolve;
		GameManager.PlaySound (successSound);
	}
}
