﻿//Author: Rok Kos <rocki5555@gmail.com>
//File: FillingBar.cs
//File path: /D/Documents/Unity/pissingsimulatorrepo/Assets/Scripts/FillingBar.cs
//Date: 29.1.2016
//Description: Script for filing bar
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FillingBar : MonoBehaviour {
	
	[SerializeField] Scoring scoringScript;

	Image FillBar; //image that is bar
	int CountHits = 0;
	public int modeBar;
	//// <summary>
	/// Custom tipe for setting image fillnes 
	/// </summary>
	public int ValueBar{
		get 
		{
		    if(FillBar != null)
		        return (int)(FillBar.fillAmount*100);	
		    else
		        return 0;	
		}
		set 
		{
			if (FillBar != null) {
					FillBar.fillAmount = value / 100f;
			}
		} 
    }

    /// <summary>
    /// Sets image and value
    /// </summary>
	void Start () {
		FillBar = gameObject.GetComponent<Image>();		
		if(modeBar == 1){
			ValueBar = scoringScript.player2Score;
		}
		if(modeBar == 2){
			ValueBar = scoringScript.amountOfScanje;
		}
		
 	}	

 	void Update(){
 		//CountHits += (int)(10 * Time.deltaTime);
		//CountHits += 1;
 		if(modeBar == 1){
 			ValueBar = scoringScript.player2Score;
 		}
 		if(modeBar == 2){
 			ValueBar = scoringScript.amountOfScanje;
 		}
 		
 		//Debug.Log(ValueBar);
 	}

}
