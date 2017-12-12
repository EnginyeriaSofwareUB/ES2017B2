using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {

	private GameObject player = null;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "map") {
			Destroy (gameObject);
			Destroy (col.gameObject);
		} else if (col.tag == "water") {
			Vector2 dir = new Vector2 (0, -1);
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.GetComponent<Rigidbody2D> ().velocity = dir;
		} else if (col.tag != player.tag && col.tag.Contains ("Jugador")) {
			col.gameObject.transform.GetChild (1).GetChild(0).GetComponent<PlayerHealth>().TakeDamage(40);
			Destroy (gameObject);
		}

	}

	public void setPlayerShooting(GameObject player) {
		this.player = player;
	}



	void OnDestroy(){
		GameObject gameC = GameObject.FindGameObjectsWithTag ("GameController")[0];
		GameController gameControllerScript = gameC.GetComponent<GameController> ();
		//recoges tag, jugador
		int turnoJugador = gameControllerScript.GetPlayerTurn ();
		GameObject jugador = GameObject.FindGameObjectsWithTag ("Jugador"+turnoJugador)[0];
		//sacos el script
		jugador.GetComponent<BulletShooter> ().setShooting(false);
		gameControllerScript.changeTurn ();
	}
}
