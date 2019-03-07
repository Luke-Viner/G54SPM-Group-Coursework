﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	//public float speed;
	public Text countText;
	public Text winText;

	//private Rigidbody rb;
	private int count;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody>();
		count = 0;
		setCountText ();
		winText.text = "";
	}

	//when player object touches trigger collider (other)
	void OnTriggerEnter(Collider other) {
		//Destroy(other.gameObject); //destroys object that causes trigger
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			setCountText ();
		}
	}


	void setCountText(){
		countText.text = "Score: " + count.ToString ();
		if (count >= 10) {
			winText.text = "Great Score!!";
		}

	}
}