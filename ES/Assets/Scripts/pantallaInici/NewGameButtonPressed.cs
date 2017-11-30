using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButtonPressed : MonoBehaviour {

	public void LoadByIndex(int index) {
		GameObject numberPlayers = GameObject.FindGameObjectsWithTag ("NumberPlayers")[0];
		if (numberPlayers.GetComponent<UnityEngine.UI.Text> ().text == "2") {
			ProjectVars.Instance.playersPrefabs ["Jugador2"] = "";
			ProjectVars.Instance.playersPrefabs ["Jugador3"] = "";
			SceneManager.LoadScene (2);

		} else {
			ProjectVars.Instance.playersPrefabs ["Jugador2"] = "Knight";
			ProjectVars.Instance.playersPrefabs ["Jugador3"] = "Knight";
			SceneManager.LoadScene (3);
		}
	}
}

