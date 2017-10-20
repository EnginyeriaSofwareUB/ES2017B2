using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    //public float speed = 5f;

    private Rigidbody2D Body;
    public float maxSpeed = 10f;

    //public bool tocaSuelo;
    //public float radio = 0.8f;
    //public LayerMask suelo;
    //public Transform pie;


	// Use this for initialization
	void Start () {
        Body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        float Direction = Input.GetAxis("Horizontal");
        Body.velocity = new Vector3(Direction * maxSpeed, transform.position.y, transform.position.z);

        //tocaSuelo = Physics2D.OverlapCircle(pie.position, radio, suelo);


        /*
        //Moviment horitzontal
        float hInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(hInput * speed * Time.deltaTime, 0, 0);

        // Moviment vertical
        float vInput = Input.GetAxis("Vertical");
        transform.position += new Vector3(0,vInput* speed * Time.deltaTime, 0);
        */

    }
}
