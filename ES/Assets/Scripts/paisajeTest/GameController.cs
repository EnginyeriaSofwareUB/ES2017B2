using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	//array con todos los jugadores

	List<string> jugadores = new List<string>{"Knight","Woman_warrior_1"};
	int numeroJugador = 0;
	private int turnoJugador = 0;

	// Use this for initialization
	void Start () {
		Vector2 position = new Vector2 (-0.953f, 0f);
		foreach(var namePrefab in jugadores )
		{

			GameObject player = (GameObject)Instantiate (Resources.Load("character/"+ namePrefab,
					typeof(GameObject)),position, Quaternion.identity);
			position.x += 20;
			player.tag = string.Concat("Jugador", numeroJugador.ToString());
			numeroJugador += 1;
		}
		initFirstTurn ();
	}

	public void initFirstTurn () {
		GameObject player = GameObject.FindGameObjectsWithTag (string.Concat("Jugador", turnoJugador.ToString()))[0];
		GameObject camera = GameObject.FindGameObjectsWithTag ("MainCamera")[0];
		camaraP1 camScript = camera.GetComponent<camaraP1> ();
		camScript.player = player;
		player.GetComponent<PlayerModel> ().turno = true;


	}

	public void changeTurn() {
		GameObject LastTurnPlayer = GameObject.FindGameObjectsWithTag (string.Concat("Jugador", turnoJugador.ToString()))[0];
		LastTurnPlayer.GetComponent<PlayerModel> ().turno = false;

		turnoJugador += 1;
		if (turnoJugador > jugadores.Count-1) {
			turnoJugador = 0;
		}
		GameObject player = GameObject.FindGameObjectsWithTag (string.Concat("Jugador", turnoJugador.ToString()))[0];
		GameObject camera = GameObject.FindGameObjectsWithTag ("MainCamera")[0];
		camaraP1 camScript = camera.GetComponent<camaraP1> ();
		camScript.player = player;
		player.GetComponent<PlayerModel> ().turno = true;

		GetComponent<scriptTimer> ().tiempo = 20f;
	}

	// Update is called once per frame
	void Update () {

	}
}
