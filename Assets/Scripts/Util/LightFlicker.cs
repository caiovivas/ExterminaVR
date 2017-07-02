using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {
	public Light light;
	public MeshRenderer mre;
	public Material ontex;
	public Material offtex;
	public AudioClip sound;
	public AudioSource asource;

	float timer = 0;
	void Update(){
		timer -= Time.deltaTime;
		if (timer <= 0) {
			if (Random.value > 0.7f) {
				light.enabled = !light.enabled;
				mre.material = (light.enabled) ? ontex : offtex;
				asource.PlayOneShot (sound);
			}
			timer = Random.Range (0.1f, 2f);
		}
	}
}
