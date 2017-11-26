using System.Collections.Generic;
using UnityEngine;

public class ProjectVars : Singleton<ProjectVars> {

	//Variables para instanciar
	public string StringActiveBetweenScenes;
	public string player1;
	public string player2;
	public string player3;
	public string player4;
	public List<string> players = new List<string>{"Knight","Knight"};


	public static ProjectVars Instance {
		get {
			return ((ProjectVars)mInstance);
		} set {
			mInstance = value;
		}
	}

	protected ProjectVars () {}
}
