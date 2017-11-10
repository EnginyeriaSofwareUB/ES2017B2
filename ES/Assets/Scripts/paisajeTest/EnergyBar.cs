using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyBar : MonoBehaviour {

	public Image energia;
	float energy;//energia del jugador
	float maxEnergy = 100f;//energia inicial de la partoda
	// Use this for initialization
	void Start () {
		energy = maxEnergy; // al principio del juego tendra la maxima energia el jugador
	}

	public void TakeDamage(float amount){
		energy = Mathf.Clamp(energy-amount,0f,maxEnergy);//Nos aseguramos que nunca pueda ser menor que 0 ni mayor que maxenergy
		energia.transform.localScale = new Vector2(energy/maxEnergy,1);//modificamos la imagen de la vida (la verde)
	}
	// Update is called once per frame
	void Update () {

	}
}
