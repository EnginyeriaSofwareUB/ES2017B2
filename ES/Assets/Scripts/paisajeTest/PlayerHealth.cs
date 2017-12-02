using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour{

	public float hp;//vida del jugador
	public float maxHp = 100;//vida inicial de la partoda
	public Image playerHealthBar;

	// Use this for initialization
	void Start () {
		hp = maxHp; // al principio del juego tendra la maxima vida el jugador
		//TakeDam(5f);
	}

	public void TakeDamage(float amount){
		hp = Mathf.Clamp(hp-amount,0f,maxHp);//Nos aseguramos que nunca pueda ser menor que 0 ni mayor que maxHp
		if(hp == 0f){//si no le queda vida, muere
			Death();
		}else{
			playerHealthBar.transform.localScale = new Vector2(hp/maxHp,1);//modificamos la imagen de la vida (la verde)
		}

	}

	public void setPlayerHealth (float powerup){
		hp = Mathf.Clamp(hp+powerup,0f,maxHp);
		playerHealthBar.transform.localScale = new Vector2(hp/maxHp,1);
	}

	public void Death(){}

	// Update is called once per frame
	void Update () {

	}
}
