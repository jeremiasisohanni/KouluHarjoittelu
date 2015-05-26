using UnityEngine;
using System.Collections;

public class cameraControls : MonoBehaviour {

	public GameObject target;
	//public float rotateSpeed = 5;
	public float horizontalSpeed = 40.0f;
	public float verticalSpeed = 40.0f;
	float h = 0.0f;
	float v = 0.0f;
	//Vector3 offset;


	// Update is called once per frame
	void Update () {
		/*	
		if (Input.GetAxis("Fire2") != 0) {
			h = horizontalSpeed * Input.GetAxis("Mouse Y");
			v = verticalSpeed * Input.GetAxis("Mouse X");
			transform.Translate(v,h,0);
		}
			*/
	}


	void LateUpdate() {
		transform.LookAt(target.transform);
	}
}
