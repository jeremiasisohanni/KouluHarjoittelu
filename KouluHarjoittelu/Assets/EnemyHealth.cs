using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyHealth : MonoBehaviour {

	public int startHealth = 100;
	public int currentHealth;
	bool isDead;
	bool damaged;

	ThirdPersonCharacter enemyMovement;

	void Start () {
		enemyMovement = GetComponent<ThirdPersonCharacter> ();
		
		currentHealth = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
		damaged = false;
	}

	public void takeDamage(int dmg) {
		damaged = true;
		
		currentHealth -= dmg;
		
		if (currentHealth <= 0 && !isDead) {
			Death();
		}
	}
	
	void Death() {
		isDead = true;
		enemyMovement.enabled = false;
	}
}

