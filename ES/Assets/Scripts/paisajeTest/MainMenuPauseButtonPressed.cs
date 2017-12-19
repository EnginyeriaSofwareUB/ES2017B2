using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuPauseButtonPressed : MonoBehaviour {


	public void MainMenuPauseButtonClicked() {
		GameObject canvas = GameObject.FindGameObjectsWithTag ("Canvas2")[0];
		Destroy (canvas);
		SceneManager.LoadScene (0);	
	}

}
