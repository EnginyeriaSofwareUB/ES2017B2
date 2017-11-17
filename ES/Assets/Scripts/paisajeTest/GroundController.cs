using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "map") {
			Destroy (gameObject);
			Destroy (col.gameObject);
		}
	}

}
