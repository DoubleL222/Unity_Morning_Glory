//Author: Rok Kos <rocki5555@gmail.com>
//File: GameController.cs
//File path: /D/Documents/Unity/pissingsimulatorrepo/Assets/Scripts/GameController.cs
//Date: 29.1.2016
//Description: Scipt for controling game
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	[SerializeField] Lulek lulekScript;
	[SerializeField] GameObject lulekPosition;
		
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.Space)){
			lulekScript.SpawnPiss();
		}
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			//Debug.Log(lulekPosition.transform.position);
			lulekPosition.transform.position = new Vector3(lulekPosition.transform.position.x, lulekPosition.transform.position.y, lulekPosition.transform.position.z + 0.1f);  
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			//Debug.Log(lulekPosition.transform.position);
			lulekPosition.transform.position = new Vector3(lulekPosition.transform.position.x, lulekPosition.transform.position.y, lulekPosition.transform.position.z - 0.1f);  
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			//Debug.Log(lulekPosition.transform.position);
			lulekPosition.transform.position = new Vector3(lulekPosition.transform.position.x + 0.1f, lulekPosition.transform.position.y, lulekPosition.transform.position.z);  
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			//Debug.Log(lulekPosition.transform.position);
			lulekPosition.transform.position = new Vector3(lulekPosition.transform.position.x - 0.1f, lulekPosition.transform.position.y, lulekPosition.transform.position.z);  
		}
	}
}
