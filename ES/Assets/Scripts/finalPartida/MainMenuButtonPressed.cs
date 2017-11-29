using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuButtonPressed : MonoBehaviour {


	public void MainMenuButtonClicked() {
		SceneManager.LoadScene (0);	
	}

}
