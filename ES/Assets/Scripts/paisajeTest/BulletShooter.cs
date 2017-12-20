using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject powerBar;
	private GUITexture powerBarTexture;
	private GameObject bullet;
	private GameObject granade;
	private bool shooting = false;
	public float velocity;
	bool chargingShoot = false;
	public Vector2 offset = new Vector2(0.4f,0.1f);
	private int granadesLeft = 2;
	private bool isGranade = false;

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
			if ((Input.GetKeyDown (KeyCode.S) || (Input.GetKeyDown(KeyCode.G) && granadesLeft > 0)) && !shooting) {
				chargingShoot = true;
				if (Input.GetKeyDown (KeyCode.G)) {
					granadesLeft--;
					isGranade = true;
				}


			}

			if (chargingShoot && ((Input.GetKeyUp (KeyCode.S) && !isGranade) || (Input.GetKeyUp (KeyCode.G) && isGranade)) || (velocity >= 128)) {
				chargingShoot = false;
				shoot ();

			}

			if (chargingShoot) {
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

		if (!isGranade) {
			bullet = (GameObject)Instantiate (projectile, (Vector2)transform.position + offset * transform.localScale.x,
				Quaternion.identity);
			bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootPower * Mathf.Cos (Mathf.Deg2Rad * angle),
				shootPower * Mathf.Sin (Mathf.Deg2Rad * angle));
			bullet.GetComponent<GroundController> ().setPlayerShooting (transform.gameObject);
		} else {
			granade = (GameObject)Instantiate (Resources.Load ("granada", typeof(GameObject)),
				(Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
			granade.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootPower * Mathf.Cos (Mathf.Deg2Rad * angle), shootPower * Mathf.Sin (Mathf.Deg2Rad * angle));
			granade.GetComponent<GroundController> ().setPlayerShooting (transform.gameObject);
			isGranade = false;
		}


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
