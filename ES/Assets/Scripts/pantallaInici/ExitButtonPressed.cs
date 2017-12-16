using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonPressed : MonoBehaviour {

	public void ExitButtonClicked() {
		Application.Quit();
		//Application.LoadLevel("1");
	}

}
