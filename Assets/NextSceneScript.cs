﻿using UnityEngine;
using System.Collections;

public class NextSceneScript : MonoBehaviour {

	// Use this for initialization
	void Start() {
		StartCoroutine(Example());
	}

	IEnumerator Example() {
		print(Time.time);
		yield return new WaitForSeconds(3);
		Application.LoadLevel ("MainMenu");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
