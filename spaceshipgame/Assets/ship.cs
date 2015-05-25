using UnityEngine;
using System.Collections;

public class ship : MonoBehaviour {

	public Rigidbody2D rb;
	public int speed = 10;
	float timer = 0f;
	bool up = false;
	bool down = false;
	bool right = false;
	bool left = false;

	bool shootside = false;
	Transform leftGun;
	Transform rightGun;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		leftGun = transform.Find ("left");
		rightGun = transform.Find ("right");
	}

	void shoot() {
		if (timer < Time.time) {
			if(shootside) {
				GameObject tmp = Instantiate(Resources.Load ("beem"), leftGun.position, leftGun.rotation) as GameObject;
				shootside = false;
				bullet tmp2 = tmp.GetComponent<bullet>();
				tmp2.speed = 80;
				tmp2.taga = transform.tag;
				timer +=0.20f;
			} else {
				GameObject tmp = Instantiate(Resources.Load("beem"), rightGun.position, rightGun.rotation) as GameObject;
				shootside = true;
				timer +=0.20f;
			}
		}

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			up = true;
		} else
				up = false;

		if (Input.GetKey (KeyCode.S)) {
			down = true;
		} else
			down = false;

		if (Input.GetKey (KeyCode.A)) {
			left = true;
		} else
			left = false;

		if (Input.GetKey (KeyCode.D)) {
			right = true;
		} else
			right = false;
	}

	void FixedUpdate() {

		Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 lookat = transform.position - mouse;
		float angle = Mathf.Atan2 (lookat.y, lookat.x) * Mathf.Rad2Deg +90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

		if (Input.GetMouseButton (0)) {
			shoot ();
		}

		if (up) {
			rb.AddForce (transform.up * speed);
		}
		if (down) {
			rb.AddForce (transform.up * -speed);
		}
		if (right) {
			rb.AddForce (transform.right * speed);
		}
		if (left) {
			rb.AddForce (transform.right * -speed);
		}
	}
}
