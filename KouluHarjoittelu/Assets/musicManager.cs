using UnityEngine;
using System.Collections;

public class musicManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetVolume(float val) {
		GetComponent<AudioSource> ().volume = val;
	}
}
