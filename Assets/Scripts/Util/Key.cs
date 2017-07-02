using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	public int currentDigit;
	public int solution;
	public bool right;
	public Keypad kp;
	public MeshRenderer mre;
	public AudioClip clickSound;

	void Start(){
		right = (currentDigit == solution);
		mre.material.mainTexture = kp.keyDigits [currentDigit];
	}

	public void OnActivate(){
		if (Vector3.Distance (GameManager.player.transform.position, transform.position) > 2f)
			return;

		if (currentDigit == kp.keyDigits.Length - 1)
			currentDigit = 0;
		else
			currentDigit++;

		mre.material.mainTexture = kp.keyDigits [currentDigit];

		right = (currentDigit == solution);

		GameManager.PlaySound (clickSound);

		kp.OnChange ();

	}
}
