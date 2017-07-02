using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaderCanvas : MonoBehaviour {

	public Image img; 

	void Start(){
		DontDestroyOnLoad (gameObject);
	}

	public void FadeIn(){
		StartCoroutine (Fade(0f,3f));
	}

	public void FadeOut(){
		StartCoroutine (Fade(1f,1.5f));
	}

	public void BlackOut(){
		img.color = new Color (0f, 0f, 0f, 1f);
	}

	IEnumerator Fade(float a, float time){
		float alpha = img.color.a;
		for (float t = 0f; t<1f; t += Time.deltaTime/time) {
			Color c = new Color (0,0,0,Mathf.Lerp(alpha,a,t));
			img.color = c;
			yield return null;
		}
		if(a == 0f)
			gameObject.SetActive (false);
	}
}
