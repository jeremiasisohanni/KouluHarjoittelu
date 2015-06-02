using UnityEngine;
using System.Collections;

public class enemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int damage = 5;

	GameObject player;
	playerHealth PlayerHealth;
	EnemyHealth enemyHealth;
	bool playerInRange;
	float timer;
	

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		PlayerHealth = player.GetComponent <playerHealth> ();
		enemyHealth = GetComponent<EnemyHealth> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player")
			playerInRange = true;
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player")
			playerInRange = false;
	}

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0) {
			Attack();
		}


	}

	void Attack() {
		timer = 0f;
		if (PlayerHealth.currentHealth > 0) 
			PlayerHealth.takeDamage (damage);
	}
}
