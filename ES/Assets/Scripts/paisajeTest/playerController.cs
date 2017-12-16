using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : MonoBehaviour {

    //public float speed = 5f;

    private Rigidbody2D Body;
    public float maxSpeed = 1.5f;

    //Variables para el salto
    public bool touchFloor; //Nos indicará si el player esta tocando el suelo
    private float radio = 0.2f;
    public LayerMask floor;
    public float maxJump = 42f;//fuerza de salto

    private GameObject energyBar; // variable apra gestionar la barra de energia
    private float playerEnergy;

    private Animator animator;
    public bool isDead; // nos indicara si el jugador esta vivo o muerto

	// Use this for initialization
	void Start () {
        Body = GetComponent<Rigidbody2D>();
        energyBar = GameObject.Find("EnergyBar");
	      animator = GetComponent<Animator> ();
        animator.SetBool ("Grounded", true);
        isDead = false;
	}

	// Update is called once per frame
	void Update () {

		if (GetComponent<PlayerModel> ().turno && !isDead)  {

			float Direction = Input.GetAxis ("Horizontal");
      Body.mass = 100f;
			//float energyPlayer = GetComponent<EnergyBar>().energy;
			if (Direction != 0 && playerEnergy > 0.0f) { // comprobamos si el usuario quiere moverse horizontalmente
				energyBar.SendMessage ("TakeEnergy", 3);//llama al metododel script energyBar y le resta la cantidad que pasamos.
				Body.velocity = new Vector2 (Direction * maxSpeed, Body.velocity.y);
			}
			GameObject foot = gameObject.transform.GetChild (0).gameObject;
			touchFloor = Physics2D.OverlapCircle (foot.transform.position, radio, floor);
			animator.SetBool ("Grounded", touchFloor);
			animator.SetFloat ("Speed", Mathf.Abs (Direction));

			//Para que el personaje gire
			if (Direction > 0) {
				transform.localScale = new Vector3 (1, 1, 1);
				GetComponentInChildren<Transform>().Find("CanvasBar").transform.rotation = Quaternion.Euler(new Vector3 (0,0,0));
			} else if (Direction < 0) {
				transform.localScale = new Vector3 (-1, 1, 1);
				GetComponentInChildren<Transform>().Find("CanvasBar").transform.rotation = Quaternion.Euler(new Vector3 (0,180,0));
			}

			//Cuando toque el suelo
			if (touchFloor) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					Body.AddForce (new Vector2 (0, maxJump * 1000));
				}
			}

			//actualizamos la energia del jugador
			playerEnergy = energyBar.GetComponent<EnergyBar> ().energy;
		}else{
      //Body.drag = 100f;
      Body.mass = 10000f;
    }
	}

  //Muerte del jugador
  public void playerDead(){
    if(!isDead){
      animator.Play("player_dead");
      isDead = true;
    }
  }



}
