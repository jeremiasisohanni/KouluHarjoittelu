using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {

	public gameManager GM;
	public musicManager MM;

	private Slider _musicSlider;

	// Use this for initialization
	void Start () {
		_musicSlider = GameObject.Find ("musicSlider").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		scanForKeyStroke();
	}

	void scanForKeyStroke() {
		if (Input.GetButtonDown ("escape"))
			GM.togglePauseMenu ();
	}

	public void musicSliderUpdate (float val) {
		MM.SetVolume (val);
	}

	public void musicToggle (bool val) {
		_musicSlider.interactable = val;
		MM.SetVolume (val ? _musicSlider.value : 0.0f);
	}
}
