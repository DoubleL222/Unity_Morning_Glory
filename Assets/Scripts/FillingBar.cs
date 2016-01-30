//Author: Rok Kos <rocki5555@gmail.com>
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
    /// Mode:
    /// 1: Player1 Score
    /// 2: Playre1 Pees Amount
    /// 3: Player2 Score
    /// 4: Playre2 Pees Amount
    /// </summary>
	void Start () {
		FillBar = gameObject.GetComponent<Image>();		
		if(modeBar == 1){
			ValueBar = scoringScript.player1Score;
		}
		if(modeBar == 2){
			ValueBar = scoringScript.amountOfScanjePly1;
		}
		if(modeBar == 3){
			ValueBar = scoringScript.player2Score;
		}
		if(modeBar == 4){
			ValueBar = scoringScript.amountOfScanjePly2;
		}
		
 	}	

 	void Update(){

 		if(modeBar == 1){
			ValueBar = scoringScript.player1Score;
		}
		if(modeBar == 2){
			ValueBar = scoringScript.amountOfScanjePly1;
		}
		if(modeBar == 3){
			ValueBar = scoringScript.player2Score;
		}
		if(modeBar == 4){
			ValueBar = scoringScript.amountOfScanjePly2;
		}
 		
 		//Debug.Log(ValueBar);
 	}

}
