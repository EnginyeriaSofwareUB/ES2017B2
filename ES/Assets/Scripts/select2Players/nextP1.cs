using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextP1 : MonoBehaviour {

	public GameObject personaje1;
	public GameObject personaje2;

	public void P1UpClicked() {
		SceneManager.LoadScene (1);
	}

	public void OnMouseDown() {

		if (Input.GetMouseButtonDown (0)) {
			personaje1.SetActive (true);
			personaje2.SetActive (true);
		}
	}
}
