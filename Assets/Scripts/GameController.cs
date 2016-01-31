//Author: Rok Kos <rocki5555@gmail.com>
//File: GameController.cs
//File path: /D/Documents/Unity/pissingsimulatorrepo/Assets/Scripts/GameController.cs
//Date: 29.1.2016
//Description: Scipt for controling game
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	[SerializeField] Scoring scoringScript;
	[SerializeField] GameObject EndScreen;
	[SerializeField] GameObject HUD;
	[SerializeField] GameObject WinText;
	[SerializeField] GameObject LoseText;
	[SerializeField] InputField inputField;
	[SerializeField] 

	private bool checkedHighScore;
	void Start(){
		//EndScreen.SetActive(false);
		HUD.SetActive(true);
		//uncoment when u want to set again high scores
		//SetPlayerPrefsHighScore();
		checkedHighScore = false;
		//Adds a listener to the main input field and invokes a method when the value changes.
		inputField.onValueChange.AddListener (delegate {InputValueChanged();});
		//inputField.enabled = false;

	}

	/// <summary>
	/// update check who wins and pauses the game
	/// </summary>
	void Update () {
		//when both are out of scanje
		if(scoringScript.amountOfScanjePly1 == 0 && scoringScript.amountOfScanjePly2 == 0){
			EndScreen.SetActive(true);
			HUD.SetActive(false);
			//inline if stavek: condition ? first_expression : second_expression;
			bool Winner = (scoringScript.player1Score > scoringScript.player2Score) ? true : false;

			if(Winner){
				WinText.GetComponent<Text>().text = "Player 1 WINS!";
				LoseText.GetComponent<Text>().text = "Sucks to be you player 2";
			}else{
				WinText.GetComponent<Text>().text = "Player 2 WINS!";
				LoseText.GetComponent<Text>().text = "Sucks to be you player 1";
			}
			if(checkedHighScore == false){
				if(scoringScript.checkHighScore()){
					inputField.enabled = true;
				}
				checkedHighScore = true;
			}
		}
	}

	public void RestartScene(){
		Debug.Log("here");
		Application.LoadLevel (Application.loadedLevelName);
	}

	public void GotoMainMenu(){
		Application.LoadLevel ("MainMenu");
	}


	void SetPlayerPrefsHighScore(){
		int[] tempArrayINT = new int[10]{1000, 900, 800, 700, 600, 500, 400, 300, 200, 100};
		string[] tempArraySTR = new string[10]{"PC Master", "Luka", "Rok", "Aljaz", "Matjaz", "Ziga", "Janez", "Micka", "Francka", "Joze"};
		PlayerPrefsX.SetIntArray ("HighScore", tempArrayINT);
		PlayerPrefsX.SetStringArray ("Names", tempArraySTR);
	}


	void InputValueChanged(){
		Debug.Log(inputField.text);
		PlayerPrefs.SetString("NameOfPlayer", inputField.text);
	}
}
