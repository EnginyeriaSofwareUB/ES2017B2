using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class playGame : MonoBehaviour {


	public void LoadByIndex(int index) {
		ProjectVars projectVarsInstace = ProjectVars.Instance;

		var keys = projectVarsInstace.playersPrefabs.Keys.ToArray ();

		foreach (string element in keys) {
			string nameCharacter = projectVarsInstace.playersPrefabs [element];

			switch (element) {
			case "Jugador0":
				if (nameCharacter != "") {
					projectVarsInstace.players.Add (nameCharacter + "_blue");
				}
				break;
			case "Jugador1":
				if (nameCharacter != "") {
					projectVarsInstace.players.Add (nameCharacter + "_red");
				}
				break;
			case "Jugador2":
				if (nameCharacter != "") {
					projectVarsInstace.players.Add (nameCharacter + "_red");
				}
				break;
			case "Jugador3":
				if (nameCharacter != "") {
					projectVarsInstace.players.Add (nameCharacter + "_blue");
				}
				break;
			}

		}
		SceneManager.LoadScene (index);
	}
}

