using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IdiomaGlobal : MonoBehaviour {
	public static string IdiomaActual = "Español";
	public Toggle toggleEspañol;
	public Toggle toggleIngles;
	public Toggle toggleCatalan;
	public bool EsEscenaMenu=true;

	void Awake(){
		//DontDestroyOnLoad (transform.gameObject);

	}
	public string RetornaIdioma(){
		return(IdiomaActual);
	}

	void Start(){
		CambiarIdioma (IdiomaActual);
	}
	public void CambiarIdioma(string idioma){
		IdiomaActual = idioma;
		NotificationCenter.DefaultCenter ().PostNotification (this, "CambiarIdioma_"); 

		if (EsEscenaMenu) {
			if (idioma == "Español") {
				//toggleEspañol. <GameObject> ().GetComponentInChildren<Image> ().gameObject.SetActive (true);
				toggleEspañol.isOn = true;

			} else if (idioma == "Ingles") {
				//toggleIngles.GetComponentInChildren <GameObject> ().GetComponentInChildren<Image> ().gameObject.SetActive (true);
				toggleIngles.isOn = true;
			} else if (idioma == "Catalan") {
				//toggleCatalan.GetComponentInChildren <GameObject> ().GetComponentInChildren<Image> ().gameObject.SetActive (true);
				toggleCatalan.isOn = true;
			}
		}

	}

}
