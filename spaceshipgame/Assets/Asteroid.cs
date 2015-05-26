using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	Rigidbody2D rb;
	int angle;
	int hp = 50;
	public float size = 2;
	public float speed = 5;
	int damage = 5;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		angle = Random.Range (0, 360);
		transform.localScale = new Vector3 (size, size, size);
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.collider.tag != "asteroid") {
			other.gameObject.SendMessageUpwards("takeDamage", damage, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3 (size, size, size);
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		rb.AddForce(transform.up * speed);
		if (hp <= 0) {
			Debug.Log("tuhoudun");
			Destroy(gameObject);
		}
	}

	void takeDamage(int d){
		hp -= d;
	}
}
