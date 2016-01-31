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
    public RectTransform transformCredits;
    public Text[] highscoreText;

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

                switch (elem.name)
                {
                    case "CreditsMenu":
                        transformCredits.position = new Vector3(transformCredits.position.x, 0, transformCredits.position.z);
                        break;
                    case "HighScoresMenu":
                        napolniHighscore();
                        break;
                }



            }
            else{
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


    void napolniHighscore()
    {
        int[] highScoreArr = PlayerPrefsX.GetIntArray("HighScore");
        string[] Names = PlayerPrefsX.GetStringArray("Names");

        //Debug.Log(highScoreArr.Length + "  " + Names.Length);

        if (highScoreArr.Length > 0 && Names.Length > 0)
        {
            if (highScoreArr.Length == Names.Length)
                for (int i = 0; i < highScoreArr.Length; i++)
                {
                    highscoreText[i].text = Names[i] + " - " + highScoreArr[i];
                }
            else
                Debug.Log("Error?");
        }
        //else
        //{
        //    int[] tempArrayINT = new int[10] { 1000, 900, 800, 700, 600, 500, 400, 300, 200, 100 };
        //    string[] tempArraySTR = new string[10] { "PC Master", "Luka", "Rok", "Aljaz", "Matjaz", "Ziga", "Janez", "Micka", "Francka", "Joze" };
        //    PlayerPrefsX.SetIntArray("HighScore", tempArrayINT);
        //    PlayerPrefsX.SetStringArray("Names", tempArraySTR);
        //    //highscoreText[0].text = "Napolnim";
        //    Debug.Log("Prazno... zaj polnim");
        //}
    }

}
