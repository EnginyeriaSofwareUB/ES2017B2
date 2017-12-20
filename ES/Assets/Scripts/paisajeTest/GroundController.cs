using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {

	private GameObject player = null;
	public bool touchedFloor = false;
	private GameObject jugador;
	private GameController gameControllerScript;
	public ParticleSystem explosion;
	private bool isGranade;

	void Awake() {
		isGranade = transform.gameObject.layer == LayerMask.NameToLayer ("granada");
	}

	void OnTriggerEnter2D(Collider2D col) {
		GameObject gameC = GameObject.FindGameObjectsWithTag ("GameController")[0];
		gameControllerScript = gameC.GetComponent<GameController> ();
		int turnoJugador = gameControllerScript.GetPlayerTurn ();
		jugador = GameObject.FindGameObjectsWithTag ("Jugador"+turnoJugador)[0];
		if (!touchedFloor && isGranade) {
			if (col.tag == "map" || col.tag.Contains ("Jugador") && col.tag != player.tag) {
				touchedFloor = true;
				Invoke("Explode", 2);
			}
		} else if (!isGranade) {
			if (col.tag == "map" || col.tag != player.tag && col.tag.Contains ("Jugador")) {
				Explode ();
				if (col.tag == "map") {
					Destroy (col.gameObject);
				}
			} else if (col.tag == "water") {
				Vector2 dir = new Vector2 (0, -1);
				float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
				transform.GetComponent<Rigidbody2D> ().velocity = dir;
			} 
		}
	}

	public void setPlayerShooting(GameObject player) {
		this.player = player;
	}

	void Explode() {
		if (isGranade) {
			AreaDamageEnemies(3, 30);
		} else {
			AreaDamageEnemies(2, ProjectVars.Instance.daño[player.tag]);
		}
		Instantiate (explosion, transform.position, Quaternion.identity);
		transform.gameObject.SetActive(false);
		Invoke ("destroyBullet", explosion.main.duration);
	}

	void destroyBullet() {
		transform.gameObject.SetActive (true);
		Destroy (gameObject);
	}

	void OnDestroy() {
		jugador.GetComponent<BulletShooter> ().setShooting(false);
		gameControllerScript.changeTurn ();
		GameObject[] particles = GameObject.FindGameObjectsWithTag ("particle");
		foreach (GameObject particle in particles) {
			Destroy (particle);
		}
	}

	void AreaDamageEnemies(float radius, float damage) {
		Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(transform.position, radius);
		foreach (Collider2D col in objectsInRange)
		{
			if (col.tag.Contains("Jugador")) {
				// linear falloff of effect
				float proximity = (transform.position - col.transform.position).magnitude;
				float effect = 1 - (proximity / radius);

				col.gameObject.transform.GetChild (1).GetChild(0).GetComponent<PlayerHealth>()
					.TakeDamage(damage * effect);
			}
				
		}
	}

}
