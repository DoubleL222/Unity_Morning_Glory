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
//	private int OnOff = 1;
	private int zacKotRotacije = 45;
	private int trKotRotacije = 0;
	private int smerRotacije = 1; 
	private float stopnjaOpitost = 9.0f;

	void Start(){
		//StartCoroutine(Pijanost(9.0f));
	}

	/// <summary>
	/// funtions that creates flasihn light
	/// vsakem fixed upadtu rotitam camero za eno stopinjo v trenutno smer ko pridem 
	//do te pozicije obrnem v dugo smer
	/// </summary>

	void FixedUpdate(){
		LightSource.transform.Rotate(0,1 * smerRotacije,0, Space.Self);
		trKotRotacije += smerRotacije;
		if(Math.Abs(trKotRotacije) >= Math.Abs(zacKotRotacije)){
			zacKotRotacije *= -1;
			smerRotacije *= -1; //pristeje minus v naslednem zato ne potrbujemo nastaviti na 1 manj
		}

		//Bluring effect
		while (blurOptimized.blurSize < stopnjaOpitost){
			blurOptimized.blurSize +=0.001f * Time.deltaTime;
		}
	}

	/// <summary>
	/// Funkcija, ki ti blura screen glede na to koliko si pijan
	/// </summary>
	IEnumerator Pijanost (float stopnja){
		Debug.Log(blurOptimized.blurSize.ToString());
		while (blurOptimized.blurSize < stopnja){
			blurOptimized.blurSize +=0.01f * Time.deltaTime;
		}
		yield return null;
	}	
}
