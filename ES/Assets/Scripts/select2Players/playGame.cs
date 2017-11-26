using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playGame : MonoBehaviour {

	public void LoadByIndex(int index) {
		string p1 = ProjectVars.Instance.player1;
		if (p1 == "" || p1 == null) {
			p1 = "Knight";
		}
		string p2 = ProjectVars.Instance.player2;
		if (p2 == "" || p2 == null) {
			p2 = "Knight";
		}
		List<string> jugadores = new List<string>{p1,p2};
		ProjectVars.Instance.players = jugadores;
		SceneManager.LoadScene (index);
	}
}

