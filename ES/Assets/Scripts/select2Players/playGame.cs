using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class playGame : MonoBehaviour {


	public void LoadByIndex(int index) {
		ProjectVars projectVarsInstace = ProjectVars.Instance;

		var keys = projectVarsInstace.playersPrefabs.Keys.ToArray ();

		foreach (string element in keys) {
			string nameCharacter = projectVarsInstace.playersPrefabs [element];
			if (nameCharacter != "") {
				projectVarsInstace.players.Add (nameCharacter);
			}
		}
		SceneManager.LoadScene (index);
	}
}

