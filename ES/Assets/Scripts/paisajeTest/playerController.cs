using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : MonoBehaviour {

    //public float speed = 5f;

    private Rigidbody2D Body;
    public float maxSpeed = 2f;

    //Variables para el salto
    public bool touchFloor; //Nos indicará si el player esta tocando el suelo
    public bool Grounded;
    public float radio = 0.8f;
    public LayerMask floor;
    public Transform foot;
    public float maxJump = 40f;//fuerza de salto

    public float Speed;

    private GameObject energyBar; // variable apra gestionar la barra de energia
    private float playerEnergy;

	// Use this for initialization
	void Start () {
        Body = GetComponent<Rigidbody2D>();
        energyBar = GameObject.Find("EnergyBar");
	}

	// Update is called once per frame
	void Update () {

      float Direction = Input.GetAxis("Horizontal");
      //float energyPlayer = GetComponent<EnergyBar>().energy;
      if(Direction != 0 && playerEnergy > 0.0f ){ // comprobamos si el usuario quiere moverse horizontalmente
        energyBar.SendMessage("TakeEnergy",3);//llama al metododel script energyBar y le resta la cantidad que pasamos.
        Body.velocity = new Vector2(Direction * maxSpeed, Body.velocity.y);
      }

      touchFloor = Physics2D.OverlapCircle(foot.position, radio, floor);
      Speed = Direction;
      Grounded = touchFloor;

      //Para que el personaje gire
      if(Direction > 0){
        transform.localScale = new Vector3(1,1,1);
      }else if(Direction < 0){
        transform.localScale = new Vector3(-1,1,1);
      }

      //Cuando toque el suelo
      if(touchFloor){
          if(Input.GetKeyDown (KeyCode.Space)){
              Body.AddForce(new Vector2(0,maxJump * 10));
        }
      }

      //actualizamos la energia del jugador
      playerEnergy = energyBar.GetComponent<EnergyBar>().energy;
    }
}
