using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : MonoBehaviour {

    //public float speed = 5f;

    private Rigidbody2D Body;
    public float maxSpeed = 20f;

    //Variables para el salto
    public bool touchFloor; //Nos indicará si el player esta tocando el suelo
    public float radio = 0.8f;
    public LayerMask floor;
    public Transform foot;
    public float maxJump = 40f;//fuerza de salto

	// Use this for initialization
	void Start () {
        Body = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

        float Direction = Input.GetAxis("Horizontal");
        Body.velocity = new Vector2(Direction * maxSpeed, Body.velocity.y);

        touchFloor = Physics2D.OverlapCircle(foot.position, radio, floor);

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

        /*
        //MOV SIN AXIS
        //Moviment horitzontal
        float hInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(hInput * speed * Time.deltaTime, 0, 0);

        // Moviment vertical
        float vInput = Input.GetAxis("Vertical");
        transform.position += new Vector3(0,vInput* speed * Time.deltaTime, 0);
        */

    }
}
