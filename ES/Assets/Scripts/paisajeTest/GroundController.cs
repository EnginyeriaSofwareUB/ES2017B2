using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "map") {
			Destroy (gameObject);
			Destroy (col.gameObject);
		} else if (col.tag == "water") {
			Vector2 dir = new Vector2(0,-1);
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.GetComponent<Rigidbody2D> ().velocity = dir;
		}
	}

}
