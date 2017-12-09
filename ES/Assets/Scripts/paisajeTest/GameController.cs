using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	//array con todos los jugadores

	List<string> jugadores = ProjectVars.Instance.players;

	//List<string> jugadores = new List<string>{"Knight","Woman_warrior_2_blue"};
	int numeroJugador = 0;
	private int turnoJugador = 0;
	private GameObject energyBar; // variable apra gestionar la barra de energia

	// Use this for initialization
	void Awake () {
		Vector2 position = new Vector2 (-0.953f, 0f);
		energyBar = GameObject.Find("EnergyBar");//Buscamos la referencia a la barra de energia
		foreach(var namePrefab in jugadores )
		{
			GameObject player = (GameObject)Instantiate (Resources.Load("character/"+ namePrefab,
					typeof(GameObject)),position, Quaternion.identity);
			position.x += 12;
			player.tag = string.Concat("Jugador", numeroJugador.ToString());
			player.transform.GetChild(0).name = string.Concat("Jugador", (numeroJugador+1).ToString()) ;
			if (numeroJugador == 0 || numeroJugador == 2) {
				IconManager.SetIcon (player.transform.GetChild (0).gameObject, IconManager.LabelIcon.Blue);
			} else {
				IconManager.SetIcon (player.transform.GetChild (0).gameObject, IconManager.LabelIcon.Red);
			}
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
		//bool shooting = false;
		energyBar.SendMessage("setEnergy",100f);
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

		//Actualizamos el player para poder gestioanr la muerte
		PlayerHealth cBarPlayer = player.GetComponentInChildren<PlayerHealth>();
		cBarPlayer.setPlayer(player);

		GetComponent<scriptTimer> ().tiempo = 20f;
		//GetComponent<scriptTimer> ().tiempo = 20f;


	}
	public int GetPlayerTurn(){
		return turnoJugador;
	}

	// Update is called once per frame
	void Update () {

	}
}
