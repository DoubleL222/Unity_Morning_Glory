//Author: Rok Kos <rocki5555@gmail.com>
//File: UIController.cs
//File path: /D/Documents/Unity/pissingsimulatorrepo/Assets/Scripts/UIController.cs
//Date: 30.1.2016
//Description: Script for controling UI elemnts 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIController : MonoBehaviour {

	GameObject[] findGameObj;

	// Use this for initialization
	void Awake () {
		findGameObj = GameObject.FindGameObjectsWithTag("Menu");
		enableMenu("MainMenu");
	}

	public void ExitApp(){
		Application.Quit();
	}


	/// <summary>
	/// Change menu according to button
	/// </summary>
	public void ChangeMenu(Button selectedButton){
		string regexButton = "Button";
		//parse name of button to right menu
		string strMenu = selectedButton.name.Remove(selectedButton.name.IndexOf(regexButton), regexButton.Length) + "Menu";
		//call funtion to enable the menu
		enableMenu(strMenu);
	}
	/// <summary>
	/// Enable only one menu and disable everyone else
	/// </summary>
	void enableMenu(string nameOfMenu){
		foreach (GameObject elem in findGameObj) {
			if(elem.name == nameOfMenu){
				elem.SetActive(true);
			}else{
				elem.SetActive(false);
			}
			
		}
	}
	/// <summary>
	/// Goes to selected level
	/// </summary>
	public void gotoMain(Button selectedButton){
		Application.LoadLevel(selectedButton.name);
	}

}
