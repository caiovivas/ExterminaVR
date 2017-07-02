using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gif : MonoBehaviour {
	public Texture2D[] frames;
	public float speed;
	public MeshRenderer mrenderer;
	int currentFrame;
	float timer;

	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0) {
			if (currentFrame == frames.Length - 1) {
				currentFrame = 0;
			} else
				currentFrame++;
			mrenderer.material.mainTexture = frames [currentFrame];
			timer = speed;
		}
	}
}
