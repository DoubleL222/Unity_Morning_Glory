﻿using UnityEngine;
using System.Collections;

public class LukaHydrasController: MonoBehaviour 
{
	public Lulek leviLulek;
	public Lulek desniLulek;
	public Scoring scoringScript;
	
	SixenseHand[] 	m_hands;

	Vector3	m_baseOffset;
	float 	m_sensitivity = 0.001f; // Sixense units are in mm
	bool 	m_bInitialized;

	// Use this for initialization
	void Start () 
	{
		m_hands = GetComponentsInChildren<SixenseHand>();
	}

	void FixedUpdate(){
		
		foreach (SixenseHand hand in m_hands) {
			if (IsControllerActive (hand.m_controller)) {
				if (hand.m_controller.Trigger > 0) {
					switch (hand.m_hand) {
					case SixenseHands.LEFT:
						if (scoringScript.amountOfScanjePly1 > 0) {
							leviLulek.SpawnPiss (hand.m_controller.Trigger);
							scoringScript.PlayerAmountDecrease (1);
							leviLulek.ActivatePissSystem (true);
						} else {
							leviLulek.playFinishSound ();
						}
						break;
					case SixenseHands.RIGHT:
						if (scoringScript.amountOfScanjePly2 > 0) {
							desniLulek.SpawnPiss (hand.m_controller.Trigger);
							//leviLulek.SpawnPiss ();
							scoringScript.PlayerAmountDecrease (2);
							desniLulek.ActivatePissSystem (true);
						} else {
							desniLulek.playFinishSound ();
						}
						break;
					default:
						break;
					}
				} else {
					switch (hand.m_hand) {
					case SixenseHands.LEFT:
						//if (scoringScript.amountOfScanjePly1 > 0)
							leviLulek.ActivatePissSystem (false);
						break;
					case SixenseHands.RIGHT:
						//if (scoringScript.amountOfScanjePly2 > 0)
							desniLulek.ActivatePissSystem (false);
						break;
					}
				}
			}
		}
	}
	// Update is called once per frame
	void Update () 
	{
		bool bResetHandPosition = false;

		foreach ( SixenseHand hand in m_hands )
		{
			if ( IsControllerActive( hand.m_controller ) )
			{
				/*if(hand.m_controller.Trigger > 0){
					switch (hand.m_hand) {
					case SixenseHands.LEFT:
						if(scoringScript.amountOfScanjePly1 > 0){
							//leviLulek.SpawnPiss (hand.gameObject.transform.rotation, hand.m_controller.Trigger);
							//scoringScript.PlayerAmountDecrease(1);
						}
						break;
					case SixenseHands.RIGHT:
						if(scoringScript.amountOfScanjePly2 > 0){
							//desniLulek.SpawnPiss (hand.gameObject.transform.rotation, hand.m_controller.Trigger);
							//leviLulek.SpawnPiss ();
							//scoringScript.PlayerAmountDecrease(2);
						}
						break;
					default:
						break;
					}
				}*/

				if(hand.m_controller.GetButtonDown( SixenseButtons.START )){
					bResetHandPosition = true;
				}
			}


			if ( m_bInitialized )
			{
				Vector3 targetForward = hand.m_controller.Rotation * Vector3.forward;
				Debug.DrawLine (hand.gameObject.transform.position, targetForward);
				UpdateHand( hand );
			}
		}
				
		if ( bResetHandPosition )
		{
			m_bInitialized = true;

			m_baseOffset = Vector3.zero;

			// Get the base offset assuming forward facing down the z axis of the base
			foreach ( SixenseHand hand in m_hands )
			{
				m_baseOffset += hand.m_controller.Position;
			}

			m_baseOffset /= 2;
		}
	}


	/** Updates hand position and rotation */
	void UpdateHand( SixenseHand hand )
	{
		bool bControllerActive = IsControllerActive( hand.m_controller );

		if ( bControllerActive )
		{
			hand.transform.localPosition = ( hand.m_controller.Position - m_baseOffset ) * m_sensitivity;
			hand.transform.localRotation = hand.m_controller.Rotation * hand.InitialRotation;
		}

		else
		{
			// use the inital position and orientation because the controller is not active
			hand.transform.localPosition = hand.InitialPosition;
			hand.transform.localRotation  = hand.InitialRotation;
		}
	}


	void OnGUI()
	{
		if ( !m_bInitialized )
		{
			GUI.Box( new Rect( Screen.width / 2 - 50, Screen.height - 40, 100, 30 ),  "Press Start" );
		}
	}


	/** returns true if a controller is enabled and not docked */
	bool IsControllerActive( SixenseInput.Controller controller )
	{
		return ( controller != null && controller.Enabled && !controller.Docked );
	}
}
