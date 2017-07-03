using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameObject macbonnerObject;
	public static GameObject player;
	public static int difficulty;
	public static AudioSource asource;
	public FaderCanvas fader;
	public static GameManager gm;


	//Game Vars
	public static float[] cooldowns = {30, 60, 50, 40, 35, 30, 30, 30};
	AudioClip playOnLoad;


	void Start(){
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
		gm = this;
		DontDestroyOnLoad (this.gameObject);
		macbonnerObject = GameObject.FindGameObjectWithTag ("MacBonner");
		player = GameObject.FindGameObjectWithTag ("Player");
		asource = GetComponent<AudioSource> ();
		FadeIn ();
	}

	void Update(){
		Spawner.cooldown -= Time.deltaTime;
	}

	public static void LoadScene(string scene, Vector3 spawnPoint){
		FadeOut ();
		SceneManager.LoadScene (scene);
		player.transform.position = spawnPoint;
		FadeIn ();
	}

	public void LoadScene(string scene, float delay, Vector3 spawnPoint, AudioClip closeSound){
		playOnLoad = closeSound;
		StartCoroutine (LoadAfterT(scene, delay, spawnPoint));
	}

	public static void PlaySound(AudioClip sound){
		asource.PlayOneShot (sound);
	}

	public static void FadeIn(){
		gm.fader.gameObject.SetActive (true);
		gm.fader.FadeIn ();
	}

	public static void FadeOut(){
		gm.fader.gameObject.SetActive (true);
		gm.fader.FadeOut ();
	}

	public static void BlackOut(){
		gm.fader.BlackOut ();
	}

	IEnumerator LoadAfterT(string scene, float delay, Vector3 spawnPoint){
		FadeOut ();
		yield return new WaitForSeconds (delay);
		SceneManager.LoadScene (scene);
		player.transform.position = spawnPoint;
		FadeIn ();
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){
		if (playOnLoad != null)
			PlaySound (playOnLoad);
		playOnLoad = null;
		macbonnerObject.GetComponent<Macbonner> ().Despawn ();
	}
}
