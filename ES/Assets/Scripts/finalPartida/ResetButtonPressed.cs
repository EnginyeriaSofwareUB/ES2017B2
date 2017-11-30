using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButtonPressed : MonoBehaviour {

	public void ResetButtonClicked() {
		SceneManager.LoadScene (1);	
	}
}
