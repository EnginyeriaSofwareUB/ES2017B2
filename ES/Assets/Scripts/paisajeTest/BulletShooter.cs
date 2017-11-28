using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject powerBar;
	private GUITexture powerBarTexture;
	private GameObject bullet;
	private bool shooting = false;
	public float velocity;
	bool chargingShoot = false;
	public Vector2 offset = new Vector2(0.4f,0.1f);


	// Use this for initialization
	void Start () {
		powerBar = (GameObject) Instantiate (powerBar, new Vector2(0.1f, 0.1f), Quaternion.identity);
		powerBarTexture = powerBar.GetComponent<GUITexture> ();
		powerBarTexture.pixelInset = new Rect(0, 0, 0, 10);

	}

	// Update is called once per frame
	void Update () {
		if (shooting) {
			if (bullet != null) {
				Vector2 dir = bullet.GetComponent<Rigidbody2D> ().velocity;
				float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
				bullet.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			}
		}
		if (GetComponent<PlayerModel> ().turno) {
			powerBar.SetActive (true);
			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				chargingShoot = true;
			

			}

			if (chargingShoot && (Input.GetKeyUp (KeyCode.LeftShift) || velocity >= 128)) {
				chargingShoot = false;
				shoot ();

				//******
				//GameObject gameC = GameObject.FindGameObjectsWithTag ("GameController")[0];
				//GameController gameControllerScript = gameC.GetComponent<GameController> ();
				//gameControllerScript.changeTurn ();
				//*****
			}

			if (chargingShoot) {
				//GameObject gameC = GameObject.FindGameObjectsWithTag ("GameController")[0];
				//GameController gameControllerScript = gameC.GetComponent<GameController> ();
				//gameControllerScript.changeTurn ();
				velocity += Time.deltaTime * 85.33f;
				velocity = Mathf.Clamp (velocity, 0, 128);
				powerBarTexture.pixelInset = new Rect (transform.position.x, transform.position.y, velocity, 10);
			
			}
				
		} else {
			powerBar.SetActive (false);
		}
	}

	private void shoot() {
		float shootPower = velocity / 5;

		float angle = GetComponent<PointerController> ().angle;
		bullet = (GameObject) Instantiate (projectile,(Vector2) transform.position + offset * transform.localScale.x, Quaternion.identity);
		bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootPower * Mathf.Cos(Mathf.Deg2Rad * angle), shootPower * Mathf.Sin(Mathf.Deg2Rad * angle));
		shooting = true;
		velocity = 0;
		powerBarTexture.pixelInset = new Rect(0, 0, 0, 10);



	}
	public bool isShooting(){
		return shooting;
	}
	public void setShooting(bool shooting)
	{
		this.shooting = shooting;
	}

}
