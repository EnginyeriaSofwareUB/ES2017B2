using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraP1 : MonoBehaviour {

	//objeto del cual se va hacer un seguimiento
	public GameObject player = null;
	private Vector3 distancia;
	public bool shooting;

	// Use this for initialization
	void Start () {
		//calculo la distancia entre la posicion del jugador y la posicion de la camara
		distancia =	transform.position - player.transform.position;
		distancia = new Vector3 (distancia.x , distancia.y + 2, distancia.z);
	}
	
	// Update is called once per frame
	void Update () {
		//cambiamos la posicion de la camara manteniendo siempre la distancia entre el jugador y la camara.

		if (player != null) {
			//cojo el script del bo

			shooting = player.GetComponent<BulletShooter>().isShooting();

			if (shooting) {
				//como tener la posicion de bala
				if(GameObject.FindGameObjectsWithTag ("bullet").Length>0){
					GameObject bullet = GameObject.FindGameObjectsWithTag ("bullet") [0];
					transform.position = bullet.transform.position + distancia;
				}


			} else {
				transform.position = player.transform.position + distancia;
				
			}


			
		}
		//if (player != null)

			
		
	}
		
}
