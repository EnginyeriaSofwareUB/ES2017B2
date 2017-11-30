using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour {

	public Image health;
	float hp;//vida del jugador
	float maxHp = 100f;//vida inicial de la partoda

	// Use this for initialization
	void Start () {
		hp = maxHp; // al principio del juego tendra la maxima vida el jugador
	}

	public void TakeDamage(float amount){
		hp = Mathf.Clamp(hp-amount,0f,maxHp);//Nos aseguramos que nunca pueda ser menor que 0 ni mayor que maxHp
		health.transform.localScale = new Vector2(hp/maxHp,1);//modificamos la imagen de la vida (la verde)
	}
	// Update is called once per frame
	void Update () {

	}
}
