﻿//Author: Rok Kos <rocki5555@gmail.com>
//File: Scoring.cs
//File path: /D/Documents/Unity/pissingsimulatorrepo/Assets/Scripts/Scoring.cs
//Date: 30.1.2016
//Description: Sript for scoring pee
using UnityEngine;
using System.Collections;
using System;

public class Scoring : MonoBehaviour {

	[SerializeField] Lulek lulekScript;

	public double player1Score = 0;
	public double player2Score = 0;
	public double amountOfScanjePly1 = 100;
	public double amountOfScanjePly2 = 100;
	private float zacetniCas;
	private Vector3 sredina = new Vector3(0.0f,-0.9f, 1.1f);

	void Start(){	
		zacetniCas = Time.time;
	}

	/// <summary>
	/// Function that cheks if player hit the toilet and add points to his score
	/// </summary>
	void OnCollisionEnter(Collision collision){
		//Debug.Log(collision.collider.gameObject.layer);
		Debug.Log(collision.contacts[0].point);
		Debug.Log("razdalja: " + System.Convert.ToSingle(Math.Round(PitagorovIzrek(sredina, collision.contacts[0].point), 1, MidpointRounding.ToEven)).ToString());
		//Debug.Log((zacetniCas - Time.time).ToString());
		if(collision.collider.gameObject.layer  == LayerMask.NameToLayer("Curek1")){
			//ta vrtsica najprej poklice funkcijo pitagorv izrek
			//ta vrne double in potem ga roundam na eno decimalko
			//round isto vrne double
			double razdalja = Math.Round(PitagorovIzrek(sredina, collision.contacts[0].point), 1, MidpointRounding.ToEven);
			//zracuna pretekli cas in ga pretvori v double ter rounda
			double pretekliCas = Math.Round(System.Convert.ToDouble(zacetniCas - Time.time), 1, MidpointRounding.ToEven);

			player1Score += 1 - 1 * razdalja - 0.01 * pretekliCas;
			Debug.Log(player1Score);
			//destroy pee
			Destroy(collision.collider.gameObject, 0.0f);
		}
		if(collision.collider.gameObject.layer  == LayerMask.NameToLayer("Curek2")){
			double razdalja = Math.Round(PitagorovIzrek(sredina, collision.contacts[0].point), 1, MidpointRounding.ToEven);
			double pretekliCas = Math.Round(System.Convert.ToDouble(zacetniCas - Time.time), 1, MidpointRounding.ToEven);
			player2Score += 1 - 1 * razdalja - 0.01 * pretekliCas;
			Debug.Log("Pretekli cas:" + (0.01 * pretekliCas).ToString());
			Debug.Log("Player score:" + player2Score.ToString());
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

	double PitagorovIzrek(Vector3 kord1, Vector3 kord2){
		double rez = Math.Pow(Math.Abs(kord1.x - kord2.x), 2) +  Math.Pow(Math.Abs(kord1.z - kord2.z), 2);
		return Mathf.Sqrt((float)rez);
	}

}
