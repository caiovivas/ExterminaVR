using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBGM : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject bgm = GameObject.Find ("BGM");
		Destroy(bgm);
	}

}
