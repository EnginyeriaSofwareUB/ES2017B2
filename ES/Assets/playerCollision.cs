using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		//col.transform.position = new Vector3(0,0,0);
		SceneManager.LoadScene (0);
	}
}
