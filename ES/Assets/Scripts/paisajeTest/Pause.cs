using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	/*prueba de pause*/
	Canvas canvas;
	bool activo;

	// Use this for initialization
	void Start () {
		canvas = GetComponent<Canvas> ();
		canvas.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			activo = !activo;
			canvas.enabled = activo;
			//0 bloqueado, 1 desbloqueado
			//temporizador interno del juego
			//Time.timeScale = activo
			Time.timeScale = (activo) ? 0 : 1f; 
		}
		
	}
}
