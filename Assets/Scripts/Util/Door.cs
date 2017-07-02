using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	public string key;
	public string scene;
	AudioSource asource;
	public AudioClip rattleSound;
	public AudioClip openSound;
	public AudioClip closeSound;
	Animation anim;
	public Vector3 spawningPos;

	void Start(){
		anim = GetComponent<Animation> ();
		asource = GetComponent<AudioSource> ();
	}

	public void Open(){
		if (Vector3.Distance (GameManager.player.transform.position, transform.position) > 2f)
			return;
		if (key == string.Empty || key == GameManager.player.GetComponent<PlayerMovement> ().key) {
			asource.PlayOneShot (openSound);
			GameManager.gm.LoadScene (scene, 3f, spawningPos, closeSound);
		} else
			Rattle ();
	}

	void Rattle(){
		anim.Play ("doorhandle");
		asource.PlayOneShot (rattleSound);
	}
}
