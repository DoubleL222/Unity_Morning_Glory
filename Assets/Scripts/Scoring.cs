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
	public int amountOfScanjePly1 = 100;
	public int amountOfScanjePly2 = 100;

	/// <summary>
	/// Function that cheks if player hit the toilet and add points to his score
	/// </summary>
	void OnCollisionEnter(Collision collision){
		//Debug.Log(collision.collider.gameObject.layer);
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

	public void PlayerAmountDecrease(int player){
		switch (player) {
			case 1:
			  amountOfScanjePly1--;
			  break;
			case 2:
			  amountOfScanjePly2--;
			  break;
		}
	}

}
