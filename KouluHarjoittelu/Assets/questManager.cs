using UnityEngine;
using System.Collections;

public class questManager : MonoBehaviour {

	public gameManager GM;
	
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		scanForPlayer ();
	}

	void scanForPlayer() {
		if (Input.GetButtonDown ("interact"))
			GM.toggleQuestMenu ();
	}
}
