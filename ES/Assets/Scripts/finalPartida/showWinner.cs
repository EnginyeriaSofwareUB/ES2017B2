using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showWinner : MonoBehaviour {

	public Text lifeText;

	public void SetLife() {
		if (ProjectVars.Instance.ganador == 1) {
			lifeText.text = "Ha ganado el equipo azul";
		} else {
			lifeText.text = "Ha ganado el equipo rojo";
		}
	}
}
