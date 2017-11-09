using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject powerBar;
	private GUITexture powerBarTexture;
	public float velocity;
	bool shooting = false;
	public Vector2 offset = new Vector2(0.4f,0.1f);

	// Use this for initialization
	void Start () {
		powerBar = (GameObject) Instantiate (powerBar, new Vector2(0.1f, 0.1f), Quaternion.identity);
		powerBarTexture = powerBar.GetComponent<GUITexture> ();
		powerBarTexture.pixelInset = new Rect(0, 0, 0, 10);

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			shooting = true;
		}

		if (shooting && (Input.GetKeyUp (KeyCode.LeftShift) || velocity >= 128)) {
			shooting = false;
			shoot ();
		}

		if (shooting) {
			velocity += Time.deltaTime * 85.33f;
			velocity = Mathf.Clamp (velocity, 0, 128);
			powerBarTexture.pixelInset = new Rect(transform.position.x, transform.position.y, velocity, 10);
		}
	}

	private void shoot() {
		float shootPower = velocity / 5;

		float angle = GetComponent<PointerController> ().angle;
		GameObject go = (GameObject) Instantiate (projectile,(Vector2) transform.position + offset * transform.localScale.x, Quaternion.identity);
		go.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shootPower * Mathf.Cos(Mathf.Deg2Rad * angle), shootPower * Mathf.Sin(Mathf.Deg2Rad * angle));

		velocity = 0;
		powerBarTexture.pixelInset = new Rect(0, 0, 0, 10);
	}
}
