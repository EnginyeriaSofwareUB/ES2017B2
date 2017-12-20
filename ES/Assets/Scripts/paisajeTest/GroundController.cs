using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {

	private GameObject player = null;
	public bool touchedFloor = false;
	private GameObject jugador;
	private GameController gameControllerScript;

	void OnTriggerEnter2D(Collider2D col) {
		GameObject gameC = GameObject.FindGameObjectsWithTag ("GameController")[0];
		gameControllerScript = gameC.GetComponent<GameController> ();
		int turnoJugador = gameControllerScript.GetPlayerTurn ();
		jugador = GameObject.FindGameObjectsWithTag ("Jugador"+turnoJugador)[0];
		if (!touchedFloor && transform.gameObject.layer == LayerMask.NameToLayer("granada")) {
			if (col.tag == "map" || col.tag.Contains ("Jugador") && col.tag != player.tag) {
				touchedFloor = true;
				Destroy (gameObject, 2);
			}
		} else if (transform.gameObject.layer != LayerMask.NameToLayer("granada")) {
			if (col.tag == "map") {
				Destroy (gameObject);
				Destroy (col.gameObject);
			} else if (col.tag == "water") {
				Vector2 dir = new Vector2 (0, -1);
				float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
				transform.GetComponent<Rigidbody2D> ().velocity = dir;
			} else if (col.tag != player.tag && col.tag.Contains ("Jugador")) {
				col.gameObject.transform.GetChild (1).GetChild(0).GetComponent<PlayerHealth>().TakeDamage(ProjectVars.Instance.daño[player.tag]);
				Destroy (gameObject);
			}
		}
	}

	public void setPlayerShooting(GameObject player) {
		this.player = player;
	}



	void OnDestroy(){
		
		jugador.GetComponent<BulletShooter> ().setShooting(false);
		gameControllerScript.changeTurn ();
	}
}
