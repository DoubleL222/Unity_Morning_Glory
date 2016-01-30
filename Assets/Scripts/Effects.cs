//Author: Rok Kos <rocki5555@gmail.com>
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
	[SerializeField] BlurOptimized blurOptimized;
	[SerializeField] GameObject cameraPosition;
	//Luc
	private int zacKotRotacije = 45;
	private int trKotRotacije = 0;
	private int smerRotacije = 1; 
	//Pijanost
	private float stopnjaOpitost = 10.0f;
	private float kvocientOpitostiPlus = 5f;
	private float kvocientOpitostiMinus = -1f;
	private float kvocientOpitosti = 0.0f;
	//Camera
	private float kotObracanja = 50.0f;
	private float trKotObr = 0;
	private int smerObracanja = 2;

	private Vector3 startPosition;
	//private float odaljenKoeficient = 10.0f;
	public int LevelMode = 0;


	/// <summary>
	/// setting in which mode player is
	/// </summary>
	void Start(){

		kvocientOpitosti = kvocientOpitostiPlus;

		switch (LevelMode) {
			case 1:
			  LightSource.SetActive(true);
			  blurOptimized.enabled = false;
			  break;
			case 2:
			  LightSource.SetActive(false);
				blurOptimized.enabled = true;
			  break;
			case 0:
			  LightSource.SetActive(false);
			  blurOptimized.enabled = false;
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
				blurOptimized.blurSize += kvocientOpitosti * Time.fixedDeltaTime;
				if (blurOptimized.blurSize >= stopnjaOpitost){
					kvocientOpitosti = kvocientOpitostiMinus;
				}
				if(blurOptimized.blurSize < 0){
					kvocientOpitosti = kvocientOpitostiPlus;
				}	  
			  break;
			case 0:
				cameraPosition.transform.Rotate(0, smerObracanja,0, Space.Self);
				trKotObr += smerObracanja;
				if(Math.Abs(trKotObr) >= Math.Abs(kotObracanja)){
					smerObracanja *= -1;
				}
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
