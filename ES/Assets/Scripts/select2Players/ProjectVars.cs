using System.Collections.Generic;
using UnityEngine;

public class ProjectVars : MonoBehaviour{

	private static ProjectVars _instance;
	//Variables para instanciar
	public Dictionary<string, string> playersPrefabs = new Dictionary<string, string>(){
		{"Jugador0","Knight"},
		{"Jugador1","Knight"},
		{"Jugador2","Knight"},
		{"Jugador3","Knight"}
	};

	public Dictionary<string, string> weaponsPlayers = new Dictionary<string, string>(){
		{"Jugador0","arma_4"},
		{"Jugador1","arma_4"},
		{"Jugador2","arma_4"},
		{"Jugador3","arma_4"}
	};

	public List<string> players = new List<string>();

	public static ProjectVars Instance { get { return _instance; } }

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		} else {
			_instance = this;
		}
	}

	protected ProjectVars () {}
}
