using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public bool isTicket;
	public string keyValue;
	public AudioClip pickupSound;

	public void Pick(){
		if (Vector3.Distance (GameManager.player.transform.position, transform.position) > 2f)
			return;
		if (keyValue != string.Empty)
			GameManager.player.GetComponent<PlayerMovement> ().key = keyValue;
		if (isTicket)
			GameManager.player.GetComponent<PlayerMovement> ().AddTicket ();
		
		GameManager.PlaySound (pickupSound);
		Destroy (gameObject);
	}
}
