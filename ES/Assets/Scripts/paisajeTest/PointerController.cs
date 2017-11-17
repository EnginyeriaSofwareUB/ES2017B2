using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour {
	
	public GameObject pointer;
	//GameObject pointer;
	int offset = 3;
	public float angle = 0;
	bool decreasing, increasing = false;
	public Vector3 pointerPosition;
	// Use this for initialization
	void Start () {
		pointer = Instantiate (pointer);
	}

	// Update is called once per frame
	void Update () {
		if (GetComponent<PlayerModel> ().turno) {
			pointer.SetActive (true);
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

			pointerPosition = new Vector3 (xPosition, yPosition, transform.position.z);

			pointer.transform.position = pointerPosition;

		} else {
			pointer.SetActive (false);
		}
	}

}
