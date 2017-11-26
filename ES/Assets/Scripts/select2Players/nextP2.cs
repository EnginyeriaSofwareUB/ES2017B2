using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextP2 : MonoBehaviour {

	public GameObject personaje1;
	public GameObject personaje2;
	public GameObject personaje3;
	public GameObject personaje4;

	public void OnMouseDown() {
		if (Input.GetMouseButtonDown (0)) {
			if (personaje1.activeSelf) {
				personaje1.SetActive (false);
				personaje2.SetActive (true);
				personaje3.SetActive (false);
				personaje4.SetActive (false);
				ProjectVars.Instance.player2 = "Robot";
			} else if (personaje2.activeSelf) {
				personaje1.SetActive (false);
				personaje2.SetActive (false);
				personaje3.SetActive (true);
				personaje4.SetActive (false);
				ProjectVars.Instance.player2 = "Woman_warrior_1";
			} else if (personaje3.activeSelf) {
				personaje1.SetActive (false);
				personaje2.SetActive (false);
				personaje3.SetActive (false);
				personaje4.SetActive (true);
				ProjectVars.Instance.player2 = "Woman_warrior_2";
			} else if (personaje4.activeSelf) {
				personaje1.SetActive (true);
				personaje2.SetActive (false);
				personaje3.SetActive (false);
				personaje4.SetActive (false);
				ProjectVars.Instance.player2 = "Knight";
			} 
		}
	}
}
