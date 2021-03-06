﻿//Author: Rok Kos <rocki5555@gmail.com>
//File: Effects.cs
//File path: /D/Documents/Unity/pissingsimulatorrepo/Assets/Scripts/Effects.cs
//Date: 30.1.2016
//Description: Script for managaing effects

using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.ImageEffects;

public class Effects : MonoBehaviour {

	[SerializeField] GameObject LightSource;
	[SerializeField] BlurOptimized blurOptimized1;
	[SerializeField] BlurOptimized blurOptimized2;
	//[SerializeField] GameObject cameraPosition;
	[SerializeField] Renderer barvaVode;
	[SerializeField] Scoring scoringScript;
	//Luc
	private int zacKotRotacije = 45;
	private int trKotRotacije = 0;
	private int smerRotacije = 1; 
	//Pijanost
	private float stopnjaOpitost = 10.0f;
	private float kvocientOpitostiPlus = 9f;
	private float kvocientOpitostiMinus = -4f;
	private float kvocientOpitosti = 0.0f;
	//Camera
	private float kotObracanja = 50.0f;
	private float trKotObr = 0;
	private int smerObracanja = 2;
	private float dvigCamere = 10.0f;

	private Vector3 startPosition;
	//private float odaljenKoeficient = 10.0f;
	public int LevelMode = 0;


	/// <summary>
	/// setting in which mode player is
	/// </summary>
	void Start(){

		barvaVode.material.SetColor("_RefrColor", Color.red);

		kvocientOpitosti = kvocientOpitostiPlus;

		switch (LevelMode) {
			case 1:
			  LightSource.SetActive(true);
			  blurOptimized1.enabled = false;
			  blurOptimized2.enabled = false;
			  break;
			case 2:
				LightSource.SetActive(false);
				blurOptimized1.enabled = true;
				blurOptimized2.enabled = true;
			  break;
			case 0:
			  LightSource.SetActive(false);
				blurOptimized1.enabled = false;
				blurOptimized2.enabled = false;
			  break;
		}
		//StartCoroutine(Pijanost(9.0f));
		//startPosition = cameraPosition.transform.position;
	}

	/// <summary>
	/// funtions that creates flasihn light
	/// vsakem fixed upadtu rotitam camero za eno stopinjo v trenutno smer ko pridem 
	//do te pozicije obrnem v dugo smer
	/// </summary>

	void Update(){

		barvaVode.material.SetColor("_RefrColor", Color.Lerp(Color.white, Color.yellow, (float) (scoringScript.player2Score + scoringScript.player1Score) / (float)scoringScript.amountOfScanjeSplosni));

		switch (LevelMode) {
			case 1:
				LightSource.transform.Rotate(0,1 * smerRotacije,0, Space.Self);
				trKotRotacije += smerRotacije;
				if(Math.Abs(trKotRotacije) >= Math.Abs(zacKotRotacije)){
					zacKotRotacije *= -1;
					smerRotacije *= -1; //pristeje minus v naslednem zato ne potrbujemo nastaviti na 1 manj
				}	  
			  break;
			case 2:
				//Bluring effect
				blurOptimized1.blurSize += kvocientOpitosti * Time.fixedDeltaTime;
				if (blurOptimized1.blurSize >= stopnjaOpitost){
					kvocientOpitosti = kvocientOpitostiMinus;
				}
				if(blurOptimized1.blurSize < 0){
					kvocientOpitosti = kvocientOpitostiPlus;
				}	
				blurOptimized2.blurSize += kvocientOpitosti * Time.fixedDeltaTime;
				if (blurOptimized2.blurSize >= stopnjaOpitost){
					kvocientOpitosti = kvocientOpitostiMinus;
				}
				if(blurOptimized2.blurSize < 0){
					kvocientOpitosti = kvocientOpitostiPlus;
				}	
			  break;
			case 0:
				//if(cameraEffect == 1){
					//levo desno
					//cameraPosition.transform.Rotate(0, smerObracanja,0, Space.Self);
					//trKotObr += smerObracanja;
					//if(Math.Abs(trKotObr) >= Math.Abs(kotObracanja)){
					//	smerObracanja *= -1;
					//}
				//}else{
				//	if()
				//}
			  break;
			}
	}

	// void Update(){
	// 	if(Input.GetKey(KeyCode.Space)){
	// 		Debug.Log("here");
			//cameraPosition.transform.position += transform.forward * odaljenKoeficient;
			//startPosition = cameraPosition.transform.position;
			//odaljenKoeficient *= -1;

	// 	}
	// }

	/// <summary>
	/// Funkcija, ki ti blura screen glede na to koliko si pijan
	/// </summary>
	// IEnumerator Pijanost (float stopnja){
	// 	Debug.Log(blurOptimized.blurSize.ToString());
	// 	while (blurOptimized.blurSize < stopnja){
	// 		blurOptimized.blurSize +=0.01f * Time.deltaTime;
	// 	}
	// 	yield return null;
	// }	
}
