using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltBoard : MonoBehaviour {

	public Vector3 currentRot;
	float rotateAmount = (float) 0.5;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		currentRot = GetComponent<Transform> ().eulerAngles;

		if((Input.GetAxis("Vertical") > 0) && (currentRot.x <= 8 || currentRot.x >= 350)){
			transform.Rotate (rotateAmount, 0, 0);
		}

		if((Input.GetAxis("Vertical") < 0) && (currentRot.x >= 351 || currentRot.x <= 9)){
			transform.Rotate (-rotateAmount, 0, 0);
		}
		if((Input.GetAxis("Horizontal") > 0) && (currentRot.z >= 351 || currentRot.z <= 9)){
			transform.Rotate (0, 0, -rotateAmount);
		}

		if((Input.GetAxis("Horizontal") < 0) && (currentRot.z <= 8 ||currentRot.z >= 350)){
			transform.Rotate (0, 0, rotateAmount);
		}
	}
}