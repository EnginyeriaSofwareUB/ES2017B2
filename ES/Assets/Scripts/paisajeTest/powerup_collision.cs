using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup_collision : MonoBehaviour {

  private GameObject energyBar; // variable apra gestionar la barra de energia

	// Use this for initialization
	void Start () {
  	energyBar = GameObject.Find("EnergyBar");
	}

	void OnTriggerEnter2D(Collider2D col) {
		//Comprobamos que tipo de power up es
		if(gameObject.tag == "powerup_energy"){
			energyBar.SendMessage ("setEnergy", 100);//Recuperamos energia
		}
		else{
			col.gameObject.transform.GetChild (1).GetChild(0).GetComponent<PlayerHealth>().setPlayerHealth(20);
		}
		Destroy(gameObject);
	}


}
