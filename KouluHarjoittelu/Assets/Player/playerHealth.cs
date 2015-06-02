using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class playerHealth : MonoBehaviour {

	public int startHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

	bool isDead;
	bool damaged;

	ThirdPersonUserControl playerMovement;

	// Use this for initialization
	void Start () {
		playerMovement = GetComponent<ThirdPersonUserControl> ();

		currentHealth = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			damageImage.color = flashColour;
		} else {
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}

		damaged = false;

	}

	public void takeDamage(int dmg) {
		damaged = true;

		currentHealth -= dmg;

		healthSlider.value = currentHealth;

		if (currentHealth <= 0 && !isDead) {
			Death();
		}
	}

	void Death() {
		isDead = true;
		playerMovement.enabled = false;
	}
}
