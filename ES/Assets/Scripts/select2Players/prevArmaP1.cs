﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prevArmaP1 : MonoBehaviour {

	public GameObject personaje1;
	public GameObject personaje2;
	public GameObject personaje3;
	public GameObject personaje4;
	public GameObject personaje5;

	public void OnMouseDown() {
		if (Input.GetMouseButtonDown (0)) {
			if (personaje1.activeSelf) {
				personaje1.SetActive (false);
				personaje2.SetActive (false);
				personaje3.SetActive (false);
				personaje4.SetActive (false);
				personaje5.SetActive (true);
				ProjectVars.Instance.weaponsPlayers [transform.tag] = "pistola_2";
				ProjectVars.Instance.daño [transform.tag] = 40;
			} else if (personaje2.activeSelf) {
				personaje1.SetActive (true);
				personaje2.SetActive (false);
				personaje3.SetActive (false);
				personaje4.SetActive (false);
				personaje5.SetActive (false);
				ProjectVars.Instance.weaponsPlayers[transform.tag] = "arma_4";
				ProjectVars.Instance.daño [transform.tag] = 50;
			} else if (personaje3.activeSelf) {
				personaje1.SetActive (false);
				personaje2.SetActive (true);
				personaje3.SetActive (false);
				personaje4.SetActive (false);
				personaje5.SetActive (false);
				ProjectVars.Instance.weaponsPlayers[transform.tag] = "pistola";
				ProjectVars.Instance.daño [transform.tag] = 30;
			} else if (personaje4.activeSelf) {
				personaje1.SetActive (false);
				personaje2.SetActive (false);
				personaje3.SetActive (true);
				personaje4.SetActive (false);
				personaje5.SetActive (false);
				ProjectVars.Instance.weaponsPlayers[transform.tag] = "arco";
				ProjectVars.Instance.daño [transform.tag] = 10;
			}  else if (personaje5.activeSelf) {
				personaje1.SetActive (false);
				personaje2.SetActive (false);
				personaje3.SetActive (false);
				personaje4.SetActive (true);
				personaje5.SetActive (false);
				ProjectVars.Instance.weaponsPlayers[transform.tag] = "arma_5";
				ProjectVars.Instance.daño [transform.tag] = 80;
			}
		}
	}
}
