using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winnerPlayer : MonoBehaviour {

	public GameObject personaje1;
	public GameObject personaje2;
	public GameObject personaje3;
	public GameObject personaje4;
	public int player;

	// Use this for initialization
	void Start () {
		if (ProjectVars.Instance.players.Count == 2) {
			show_animations_1_vs_1 ();
		} else {
			show_animations_2_vs_2 ();
		}
	}

	void show_animations_1_vs_1 () {
		// Team blue win
		if (player == 1 && ProjectVars.Instance.ganador == 1) {
			if (ProjectVars.Instance.players[0] == "Knight") {
				personaje1.SetActive (true);
			}
			if (ProjectVars.Instance.players[0] == "Robot") {
				personaje2.SetActive (true);
			}
			if (ProjectVars.Instance.players[0] == "Woman_warrior_1") {
				personaje3.SetActive (true);
			}
			if (ProjectVars.Instance.players[0] == "Woman_warrior_2") {
				personaje4.SetActive (true);
			}
		} 
		// Team blue lose
		if (player == 5 && ProjectVars.Instance.ganador == 2) {
			if (ProjectVars.Instance.players[0] == "Knight") {
				personaje1.SetActive (true);
			}
			if (ProjectVars.Instance.players[0] == "Robot") {
				personaje2.SetActive (true);
			}
			if (ProjectVars.Instance.players[0] == "Woman_warrior_1") {
				personaje3.SetActive (true);
			}
			if (ProjectVars.Instance.players[0] == "Woman_warrior_2") {
				personaje4.SetActive (true);
			}
		}
		// Team red win
		if (player == 3 && ProjectVars.Instance.ganador == 2) {
			if (ProjectVars.Instance.players[1] == "Knight") {
				personaje1.SetActive (true);
			}
			if (ProjectVars.Instance.players[1] == "Robot") {
				personaje2.SetActive (true);
			}
			if (ProjectVars.Instance.players[1] == "Woman_warrior_1") {
				personaje3.SetActive (true);
			}
			if (ProjectVars.Instance.players[1] == "Woman_warrior_2") {
				personaje4.SetActive (true);
			}
		}
		// Team red lose
		if (player == 7 && ProjectVars.Instance.ganador == 1) {
			if (ProjectVars.Instance.players[1] == "Knight") {
				personaje1.SetActive (true);
			}
			if (ProjectVars.Instance.players[1] == "Robot") {
				personaje2.SetActive (true);
			}
			if (ProjectVars.Instance.players[1] == "Woman_warrior_1") {
				personaje3.SetActive (true);
			}
			if (ProjectVars.Instance.players[1] == "Woman_warrior_2") {
				personaje4.SetActive (true);
			}
		}
	}

	void show_animations_2_vs_2 () {
		// Team blue win
		if (player == 1 && ProjectVars.Instance.ganador == 1) {
			if (ProjectVars.Instance.players[0] == "Knight") {
				personaje1.SetActive (true);
			}
			if (ProjectVars.Instance.players[0] == "Robot") {
				personaje2.SetActive (true);
			}
			if (ProjectVars.Instance.players[0] == "Woman_warrior_1") {
				personaje3.SetActive (true);
			}
			if (ProjectVars.Instance.players[0] == "Woman_warrior_2") {
				personaje4.SetActive (true);
			}
		}
		if (player == 2 && ProjectVars.Instance.ganador == 1) {
			if (ProjectVars.Instance.players[2] == "Knight") {
				personaje1.SetActive (true);
			}
			if (ProjectVars.Instance.players[2] == "Robot") {
				personaje2.SetActive (true);
			}
			if (ProjectVars.Instance.players[2] == "Woman_warrior_1") {
				personaje3.SetActive (true);
			}
			if (ProjectVars.Instance.players[2] == "Woman_warrior_2") {
				personaje4.SetActive (true);
			}
		}
		// Team blue lose
		if (player == 5 && ProjectVars.Instance.ganador == 2) {
			if (ProjectVars.Instance.players[0] == "Knight") {
				personaje1.SetActive (true);
			}
			if (ProjectVars.Instance.players[0] == "Robot") {
				personaje2.SetActive (true);
			}
			if (ProjectVars.Instance.players[0] == "Woman_warrior_1") {
				personaje3.SetActive (true);
			}
			if (ProjectVars.Instance.players[0] == "Woman_warrior_2") {
				personaje4.SetActive (true);
			}
		}
		if (player == 6 && ProjectVars.Instance.ganador == 2) {
			if (ProjectVars.Instance.players[2] == "Knight") {
				personaje1.SetActive (true);
			}
			if (ProjectVars.Instance.players[2] == "Robot") {
				personaje2.SetActive (true);
			}
			if (ProjectVars.Instance.players[2] == "Woman_warrior_1") {
				personaje3.SetActive (true);
			}
			if (ProjectVars.Instance.players[2] == "Woman_warrior_2") {
				personaje4.SetActive (true);
			}
		}
		// Team red win
		if (player == 3 && ProjectVars.Instance.ganador == 2) {
			if (ProjectVars.Instance.players[1] == "Knight") {
				personaje1.SetActive (true);
			}
			if (ProjectVars.Instance.players[1] == "Robot") {
				personaje2.SetActive (true);
			}
			if (ProjectVars.Instance.players[1] == "Woman_warrior_1") {
				personaje3.SetActive (true);
			}
			if (ProjectVars.Instance.players[1] == "Woman_warrior_2") {
				personaje4.SetActive (true);
			}
		}
		if (player == 4 && ProjectVars.Instance.ganador == 2) {
			if (ProjectVars.Instance.players[3] == "Knight") {
				personaje1.SetActive (true);
			}
			if (ProjectVars.Instance.players[3] == "Robot") {
				personaje2.SetActive (true);
			}
			if (ProjectVars.Instance.players[3] == "Woman_warrior_1") {
				personaje3.SetActive (true);
			}
			if (ProjectVars.Instance.players[3] == "Woman_warrior_2") {
				personaje4.SetActive (true);
			}
		}
		// Team red lose
		if (player == 7 && ProjectVars.Instance.ganador == 1) {
			if (ProjectVars.Instance.players[1] == "Knight") {
				personaje1.SetActive (true);
			}
			if (ProjectVars.Instance.players[1] == "Robot") {
				personaje2.SetActive (true);
			}
			if (ProjectVars.Instance.players[1] == "Woman_warrior_1") {
				personaje3.SetActive (true);
			}
			if (ProjectVars.Instance.players[1] == "Woman_warrior_2") {
				personaje4.SetActive (true);
			}
		}
		if (player == 8 && ProjectVars.Instance.ganador == 1) {
			if (ProjectVars.Instance.players[3] == "Knight") {
				personaje1.SetActive (true);
			}
			if (ProjectVars.Instance.players[3] == "Robot") {
				personaje2.SetActive (true);
			}
			if (ProjectVars.Instance.players[3] == "Woman_warrior_1") {
				personaje3.SetActive (true);
			}
			if (ProjectVars.Instance.players[3] == "Woman_warrior_2") {
				personaje4.SetActive (true);
			}
		}
	}
}
