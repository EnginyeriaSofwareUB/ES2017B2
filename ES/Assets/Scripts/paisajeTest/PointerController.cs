using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour {
	
	public GameObject pointerResource;
	GameObject pointer;
	int offset = 3;
	float angle = 0;
	bool decreasing, increasing = false;
	// Use this for initialization
	void Start () {
		pointer = Instantiate (pointerResource);

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			decreasing = true;
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			increasing = true;
		}

		if (increasing) {
			angle += 1;
		}

		if (decreasing) {
			angle -= 1;
		}

		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			decreasing = false;
		} else if (Input.GetKeyUp (KeyCode.UpArrow)) {
			increasing = false;
		}

		//Updating cursor position
		float xPosition = Mathf.Cos (Mathf.Deg2Rad * angle) * offset + transform.position.x;
		float yPosition = Mathf.Sin (Mathf.Deg2Rad * angle) * offset + transform.position.y;

		pointer.transform.position = new Vector3 (xPosition, yPosition, transform.position.z);
	}
}
