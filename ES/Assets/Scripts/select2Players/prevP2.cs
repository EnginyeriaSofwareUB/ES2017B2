using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prevP2 : MonoBehaviour {

	public GameObject personaje1;
	public GameObject personaje2;

	public void OnMouseDown() {
		if (Input.GetMouseButtonDown (0)) {
			if (personaje1.activeSelf) {
				personaje1.SetActive (false);
				personaje2.SetActive (true);
			} else if (personaje2.activeSelf) {
				personaje1.SetActive (true);
				personaje2.SetActive (false);
			}
		}
	}
}
