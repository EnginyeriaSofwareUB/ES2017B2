using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLimitController : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag.Contains("Jugador")){
			col.gameObject.transform.GetChild (1).GetChild(0).GetComponent<PlayerHealth>().setPlayer(col.gameObject);
			col.gameObject.transform.GetChild (1).GetChild(0).GetComponent<PlayerHealth>().TakeDamage(100); // le qutiamos la vida
			GameObject gameC = GameObject.FindGameObjectsWithTag ("GameController")[0];
			GameController gameControllerScript = gameC.GetComponent<GameController> ();
			gameControllerScript.changeTurn();
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "bullet") {

			Destroy (col.gameObject);
			//SceneManager.LoadScene (4);
		}
	}
}
