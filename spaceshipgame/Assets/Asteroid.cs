using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	Rigidbody2D rb;
	int angle;
	int hp = 50;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		angle = Random.Range (0, 360);
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		rb.AddForce(transform.up * 5);
		if (hp <= 0) {
			Debug.Log("tuhoudun");
			Destroy(gameObject);
		}
	}

	void takeDamage(int d){
		hp -= d;
	}
}
