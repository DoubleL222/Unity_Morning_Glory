//Author: Rok Kos <rocki5555@gmail.com>
//File: Effects.cs
//File path: /D/Documents/Unity/pissingsimulatorrepo/Assets/Scripts/Effects.cs
//Date: 30.1.2016
//Description: Script for managaing effects

using UnityEngine;
using System.Collections;

public class Effects : MonoBehaviour {

	[SerializeField] GameObject LightSource;
	private int OnOff = 1; 

	/// <summary>
	/// funtions that creates flasihn light
	/// </summary>
	void LightOnOff(int smer){
		//smer tels in whic direction to rotate light
		// -1 dark
		//1 light
		LightSource.transform.Rotate(0,90 * smer,0, Space.Self);
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			LightOnOff(OnOff);
			OnOff *= -1;
		}
	}	
}
