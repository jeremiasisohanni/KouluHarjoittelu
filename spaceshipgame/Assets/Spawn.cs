using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public float delay = 0;
	float time = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (time < Time.time) {
			GameObject tmp = Instantiate(Resources.Load ("Asteroid"), transform.position, transform.rotation) as GameObject;
			Asteroid tmp2 = tmp.GetComponent<Asteroid>();
			tmp2.size = Random.Range(1.5f, 4.0f);
			tmp2.speed = Random.Range(3.0f, 8.0f);
			time = Time.time + delay;
		}
	}
}
