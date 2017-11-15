using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextP2 : MonoBehaviour {

	public GameObject personaje1;
	public GameObject personaje2;

	public void OnMouseDown() {
		if (Input.GetMouseButtonDown (0)) {
			personaje1.SetActive (false);
			personaje2.SetActive (true);
		}
	}
}
