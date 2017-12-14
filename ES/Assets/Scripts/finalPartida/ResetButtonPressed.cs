using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButtonPressed : MonoBehaviour {

	public void ResetButtonClicked() {
		ProjectVars.Instance.ganador = 0;
		SceneManager.LoadScene (1);	
	}
}
