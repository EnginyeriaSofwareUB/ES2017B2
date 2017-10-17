using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptTimer : MonoBehaviour {

	public Text contador;
	public Text fin;
	////private float tiempo;
	private float tiempo=60f;

	// Use this for initialization
	void Start () {
		contador.text = " " + tiempo;
		fin.enabled = false;
		///tiempo = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		tiempo -= Time.deltaTime;
		contador.text = " " + tiempo.ToString("f0");

		//comprobacion
		if (tiempo <= 0) 
		{
			contador.text = "00";
			fin.enabled = true;

		}
		//float t = Time.time - tiempo;
		//string minutos = ((int)t / 60).ToString();
		//string segundos = (t % 60).ToString ("f2");
		//contador.text = minutos + ":" + segundos;

	}
}
