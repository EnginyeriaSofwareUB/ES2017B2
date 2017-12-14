using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showWinner : MonoBehaviour {

	[SerializeField]
	private Text winner = null;

	// Use this for initialization
	void Start () {
		if (ProjectVars.Instance.ganador == 1) {
			winner.text = "Team blue wins!";
			winner.color = Color.blue;
		} else if (ProjectVars.Instance.ganador == 2) {
			winner.text = "Team Red wins!";
			winner.color = Color.red;
		} else {
			winner.text = "Game over";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
