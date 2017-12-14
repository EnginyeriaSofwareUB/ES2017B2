using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	//array con todos los jugadores

	List<string> jugadores = ProjectVars.Instance.players;

	//List<string> jugadores = new List<string>{"Knight","Woman_warrior_2_blue"};
	int numeroJugador = 0;
	private int turnoJugador = 0;
	private GameObject energyBar; // variable apra gestionar la barra de energia
	private int numeroTurno = 1;

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

	void finishGame () {
		SceneManager.LoadScene (4);
	}
 
	public void changeTurn() {

		checkGameStatus();//Comprobamos si hay un ganador antes de empezar el turno
		if (ProjectVars.Instance.ganador == 1 || ProjectVars.Instance.ganador == 2) {
			Invoke ("finishGame", 3f);
		}
		//bool shooting = false;
		energyBar.SendMessage("setEnergy",100f);
		GameObject LastTurnPlayer = GameObject.FindGameObjectsWithTag (string.Concat("Jugador", turnoJugador.ToString()))[0];
		LastTurnPlayer.GetComponent<PlayerModel> ().turno = false;
		turnoJugador += 1;
		if (turnoJugador > jugadores.Count-1) {
			turnoJugador = 0;
			numeroTurno += 1;
			if (numeroTurno > 4) {
				if (numeroTurno == 5) {
					reduceMap (true);
				} else {
					reduceMap (false);
				}
			}

		}


		GameObject player = GameObject.FindGameObjectsWithTag (string.Concat("Jugador", turnoJugador.ToString()))[0];
		//Miramos si el player que le toca jugar esta vivo
		playerController ctr = player.GetComponentInChildren<playerController>();
		if(ctr.isDead){ // si esta muerto cambiamos de turno a otro player
			changeTurn();
		}
		else{
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



	}

	public int GetPlayerTurn(){
		return turnoJugador;
	}

	private void reduceMap(bool firstTime) {
		GameObject[] mapLimits = GameObject.FindGameObjectsWithTag ("limit");
		GameObject leftLimit = mapLimits [2];
		GameObject rightLimit = mapLimits [1];

		if (firstTime) {
			leftLimit.transform.position = new Vector3(-15.5f,leftLimit.transform.position.y, leftLimit.transform.position.z );
			rightLimit.transform.position = new Vector3(60f,rightLimit.transform.position.y, rightLimit.transform.position.z );
		} else {
			leftLimit.transform.position = new Vector3(leftLimit.transform.position.x +3,leftLimit.transform.position.y, leftLimit.transform.position.z );
			rightLimit.transform.position = new Vector3(rightLimit.transform.position.x -3,rightLimit.transform.position.y, rightLimit.transform.position.z );

		}
	}

	public void checkGameStatus(){
		if(jugadores.Count == 2){ // Si solo tenemos 2 jugadores
			//Debug.Log("Partida de 2 jugadores");
			GameObject player1 = GameObject.FindGameObjectsWithTag ("Jugador0")[0];
			GameObject player2 = GameObject.FindGameObjectsWithTag ("Jugador1")[0];
			playerController ctr1 = player1.GetComponentInChildren<playerController>();
			playerController ctr2 = player2.GetComponentInChildren<playerController>();
			if(ctr1.isDead){
				ProjectVars.Instance.ganador = 2;//
			}

			if(ctr2.isDead){
				ProjectVars.Instance.ganador = 1; //
			}

		}
		//Para el caso de 4 jugadores
		else{
			//Debug.Log("Partida de 4 jugadores");
			GameObject player1 = GameObject.FindGameObjectsWithTag ("Jugador0")[0];
			GameObject player2 = GameObject.FindGameObjectsWithTag ("Jugador1")[0];
			GameObject player3 = GameObject.FindGameObjectsWithTag ("Jugador2")[0];
			GameObject player4 = GameObject.FindGameObjectsWithTag ("Jugador3")[0];
			playerController ctr1 = player1.GetComponentInChildren<playerController>();
			playerController ctr2 = player2.GetComponentInChildren<playerController>();
			playerController ctr3= player3.GetComponentInChildren<playerController>();
			playerController ctr4 = player4.GetComponentInChildren<playerController>();
			if(ctr1.isDead && ctr3.isDead){
				ProjectVars.Instance.ganador = 2;
			}
			else if(ctr2.isDead && ctr4.isDead){
				ProjectVars.Instance.ganador = 1;
			}


		}

	}

	// Update is called once per frame
	void Update () {

	}
}
