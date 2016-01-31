//Author: Rok Kos <rocki5555@gmail.com>
//File: Scoring.cs
//File path: /D/Documents/Unity/pissingsimulatorrepo/Assets/Scripts/Scoring.cs
//Date: 30.1.2016
//Description: Sript for scoring pee
using UnityEngine;
using System.Collections;
using System;

public class Scoring : MonoBehaviour {

	[SerializeField] GameObject ObjectWater;
	private float dvigKolicnik; //nastavi glede na povrsino

	public double player1Score = 0;
	public double player2Score = 0;
	public int amountOfScanjePly1 = 1000;
	public int amountOfScanjePly2 = 1000;
	public int amountOfScanjeSplosni = 1000;//prilagaja obema amountama
	private float zacetniCas;
	private Vector3 sredina = new Vector3(0.4f,-0.5f, -0.2f);
	private AudioSource NoiseMaker;
	float LastPissTime = 0.0f;


	void Start(){
		NoiseMaker = GetComponent<AudioSource> ();	
		zacetniCas = Time.time;
		//dvigKolicnik = 0.3f / (amountOfScanjePly1 + amountOfScanjePly2);
		dvigKolicnik = System.Convert.ToSingle(0.05f/(float)(2 * amountOfScanjeSplosni));
	}

	/// <summary>
	/// Function that cheks if player hit the toilet and add points to his score
	/// </summary>
	void OnCollisionEnter(Collision collision){
		//Debug.Log(collision.collider.gameObject.layer);
		//Debug.Log(collision.contacts[0].point);
		//Debug.Log("razdalja: " + System.Convert.ToSingle(Math.Round(PitagorovIzrek(sredina, collision.contacts[0].point), 1, MidpointRounding.ToEven)).ToString());
		//Debug.Log((zacetniCas - Time.time).ToString());
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Curek1")) {
			//ta vrtsica najprej poklice funkcijo pitagorv izrek
			//ta vrne double in potem ga roundam na eno decimalko
			//round isto vrne double
			double razdalja = Math.Round (PitagorovIzrek (sredina, collision.contacts [0].point), 1, MidpointRounding.ToEven);
			//zracuna pretekli cas in ga pretvori v double ter rounda
			double pretekliCas = Math.Round (System.Convert.ToDouble (zacetniCas - Time.time), 1, MidpointRounding.ToEven);

			player1Score += 1 - 1 * razdalja - 0.01 * pretekliCas;
			//Debug.Log(player1Score);
			//destroy pee
			LastPissTime = Time.time;
			Destroy (collision.collider.gameObject, 0.0f);
			if (!NoiseMaker.isPlaying) {
				PlayNoise ();
			}
		} else if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Curek2")) {
			double razdalja = Math.Round (PitagorovIzrek (sredina, collision.contacts [0].point), 1, MidpointRounding.ToEven);
			double pretekliCas = Math.Round (System.Convert.ToDouble (zacetniCas - Time.time), 1, MidpointRounding.ToEven);
			player2Score += 1 - 1 * razdalja - 0.01 * pretekliCas;
			//Debug.Log("Pretekli cas:" + (0.01 * pretekliCas).ToString());
			//Debug.Log("Player score:" + player2Score.ToString());
			//destroy pee
			LastPissTime = Time.time;
			Destroy (collision.collider.gameObject, 0.0f);
			if (!NoiseMaker.isPlaying) {
				PlayNoise ();
			}
		} else {
		}
		//Dvig vode kadar ga zadane curek scanja
		if(player1Score + player2Score < 2 * amountOfScanjeSplosni){
			ObjectWater.transform.position = new Vector3(ObjectWater.transform.position.x, ObjectWater.transform.position.y  + dvigKolicnik, ObjectWater.transform.position.z);	
		}
		
	}
	public void PlayNoise(){
		NoiseMaker.Play ();
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
	void FixedUpdate(){
		if (LastPissTime + 0.2f < Time.time) {
			NoiseMaker.Pause ();
			Debug.Log ("PAUSING NOISE");
		}
	}

}
