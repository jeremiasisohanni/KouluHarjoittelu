using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	public uiManager UI;
	public questManager QUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void togglePauseMenu() {
		if (UI.GetComponentInChildren<Canvas> ().enabled) {
			UI.GetComponentInChildren<Canvas> ().enabled = false;
			Time.timeScale = 1.0f;
		} else {
			UI.GetComponentInChildren<Canvas> ().enabled = true;
			Time.timeScale = 0f;
		}


	}

	public void toggleQuestMenu() {
		if (QUI.GetComponentInChildren<Canvas> ().enabled) {
			QUI.GetComponentInChildren<Canvas> ().enabled = false;
		} else {
			QUI.GetComponentInChildren<Canvas>().enabled = true;
		}
	}
}
