using UnityEngine;
using System.Collections;

public class android : MonoBehaviour {

	public GameObject target;
	public Rigidbody2D rb;
	public int speed = 5;
	public int damage = 50;
	float timer = 0.0f;

	public GameObject targetting;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		Vector3 ship = target.transform.position;
		Vector3 look = transform.position - ship;
		float angle = Mathf.Atan2 (look.y, look.x) * Mathf.Rad2Deg +90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 ship = target.transform.position;
		Vector3 look = transform.position - ship;
		float angle = Mathf.Atan2 (look.y, look.x) * Mathf.Rad2Deg +90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}

	void shoot() {
		if (timer < Time.time) {
				
				GameObject tmp = Instantiate(Resources.Load ("beem"), targetting.transform.position, targetting.transform.rotation) as GameObject;
				bullet tmp2 = tmp.GetComponent<bullet>();
				tmp2.speed = 80;
				tmp2.taga = transform.tag;
				timer = Time.time + 0.25f;
		}
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.SendMessageUpwards ("takeDamage", damage, SendMessageOptions.DontRequireReceiver);
			Destroy (gameObject);
		}
	}
	void FixedUpdate() {
		Vector3 ship = target.transform.position;

		shoot ();

		rb.AddForce (transform.up * speed);
		rb.AddForce (transform.right * speed);


	}
}
