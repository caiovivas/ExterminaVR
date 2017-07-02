using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Macbonner : MonoBehaviour {
	public static bool active;
	public static bool alerted;
	GameObject model;
	BoxCollider macCollider;
	AudioSource audioSource;
	public AudioSource seenAudio;
	public float speed;
	bool canPlay;
	GameObject deathScreen;
	public float killTimer = 0;
	NavMeshAgent agent;


	void Start(){
		DontDestroyOnLoad (this.gameObject);
		model = transform.GetChild (0).gameObject;
		audioSource = GetComponent<AudioSource> ();
		audioSource.enabled = false;
		seenAudio.enabled = true;
		deathScreen = GameObject.FindGameObjectWithTag ("DeathScreen");
		deathScreen.SetActive (false);
		macCollider = GetComponent<BoxCollider> ();
		agent = GetComponent<NavMeshAgent> ();
		Despawn ();
	}

	public void Spawn(Vector3 pos){
		model.SetActive (true);
		transform.position = new Vector3(pos.x, GameManager.player.transform.position.y, pos.z);
		alerted = false;
		active = true;
		canPlay = true;
		macCollider.enabled = true;
	}

	public void Despawn(){
		model.SetActive (false);
		agent.isStopped = true;
		StartCoroutine ("audioFade");
		Spawner.cooldown = Random.Range(5f,10f);
		active = false;
		macCollider.enabled = false;
	}

	void Update(){
		transform.LookAt (GameManager.player.transform.position);

		if (killTimer > 0) killTimer -= Time.deltaTime;
		else if (killTimer < 0) KillPlayerBackToMenu ();


		bool inPlayerSight = PlayerVision.vision.IsInPlayerSight (transform);
		if (inPlayerSight) {
			alerted = true;
			audioSource.enabled = true;
			audioSource.volume = 1;

			if (canPlay) {
				seenAudio.PlayOneShot (seenAudio.clip);
				canPlay = false;
			}
		}

		if (active && alerted) {
			agent.isStopped = false;
			agent.destination = GameManager.player.transform.position;

			if ((Vector3.Distance(transform.position, GameManager.player.transform.position) > 5f) && !PlayerVision.vision.IsInPlayerSight(transform) && !SeesPlayer()) {
				Despawn();
			}
		}
	}

	IEnumerator audioFade(){
		float startVolume = audioSource.volume;

		while (audioSource.volume > 0) {
			audioSource.volume -= startVolume * Time.deltaTime;
			yield return null;
		}
		audioSource.enabled = false;
		audioSource.volume = startVolume;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			KillPlayer ();
		}
	}

	bool SeesPlayer(){
		RaycastHit hit;
		if (Physics.Raycast (transform.position, GameManager.player.transform.position - transform.position, out hit, 100f)) {
			if (hit.transform.tag == "Player") {
				return true;
			}
		}
		return false;
	}

	void KillPlayer(){
		Despawn ();
		deathScreen.SetActive (true);
		killTimer = 10f;
	}

	void KillPlayerBackToMenu(){
		GameManager.LoadScene ("menu", new Vector3(0,0,0));
	}
}
