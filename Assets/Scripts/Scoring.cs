//Author: Rok Kos <rocki5555@gmail.com>
//File: Scoring.cs
//File path: /D/Documents/Unity/pissingsimulatorrepo/Assets/Scripts/Scoring.cs
//Date: 30.1.2016
//Description: Sript for scoring pee
using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {

	[SerializeField] Lulek lulekScript;

	public int player1Score = 0;
	public int player2Score = 0;
	public int amountOfScanje = 100;

	void Update(){
		//spawnam piss in odstejem kolicino 
		if(amountOfScanje > 0){
			//lulekScript.SpawnPiss();
			amountOfScanje--;
		}
	}


	/// <summary>
	/// Function that cheks if player hit the toilet and add points to his score
	/// </summary>
	void OnCollisionEnter(Collision collision){
		Debug.Log(collision.collider.gameObject.layer);
		if(collision.collider.gameObject.layer  == LayerMask.NameToLayer("Curek1")){
			player1Score += 1;
			//destroy pee
			Destroy(collision.collider.gameObject, 0.0f);
		}
		if(collision.collider.gameObject.layer  == LayerMask.NameToLayer("Curek2")){
			player2Score += 1;
			//destroy pee
			Destroy(collision.collider.gameObject, 0.0f);
		}
	}

}
