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
	private GameObject weapon;
	private float lastDirection;
	// Use this for initialization
	void Start () {
		pointer = Instantiate (pointer);
		string weaponName = ProjectVars.Instance.weaponsPlayers [transform.tag];
		weapon = Instantiate (Resources.Load (weaponName, typeof(GameObject))) as GameObject;
		Vector3 weaponPos = weapon.transform.position;
		weapon.transform.parent = transform;
		weapon.transform.localPosition = weaponPos;
		weapon.transform.localRotation = Quaternion.Euler (new Vector3 (0, 180, 0));
		lastDirection = transform.localScale.x;
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

			if (lastDirection != transform.localScale.x){
				angle = 180 - angle;
				lastDirection = transform.localScale.x;
			}

			if (lastDirection == 1) {
				if (increasing && angle < 90) {
					angle += 1;
				}

				if (decreasing && angle > -90) {
					angle -= 1;
				}
			} else {
				if (increasing && angle > 90) {
					angle -= 1;
				}

				if (decreasing && angle < 270) {
					angle += 1;
				}
			}

			if (Input.GetKeyUp (KeyCode.DownArrow)) {
				decreasing = false;
			} else if (Input.GetKeyUp (KeyCode.UpArrow)) {
				increasing = false;
			}

			//Updating cursor position
			float xPosition = Mathf.Cos (Mathf.Deg2Rad * angle) * offset + transform.position.x;
			float yPosition = Mathf.Sin (Mathf.Deg2Rad * angle) * offset + transform.position.y;

			pointerPosition = new Vector3 (xPosition, yPosition, -1);

			pointer.transform.position = pointerPosition;

			if (lastDirection == 1) {
				weapon.transform.localRotation = Quaternion.Euler (new Vector3 (0, 180, -angle));
			} else {
				weapon.transform.localRotation = Quaternion.Euler (new Vector3 (180, 0, angle));
			}
		} else {
			pointer.SetActive (false);
		}
	}

}
