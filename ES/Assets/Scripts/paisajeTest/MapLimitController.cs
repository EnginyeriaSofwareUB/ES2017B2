using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLimitController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag.Contains("Jugador") || col.tag == "bullet") {
			Destroy (col.gameObject);
		}
	}
}
