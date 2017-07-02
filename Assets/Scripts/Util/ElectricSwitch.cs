using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricSwitch : MonoBehaviour {

	public void OnActivate(){
		if (Vector3.Distance (GameManager.player.transform.position, transform.position) > 2f)
			return;
		GameManager.BlackOut ();
	}
}
