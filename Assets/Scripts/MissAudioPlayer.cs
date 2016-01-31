using UnityEngine;
using System.Collections;

public class MissAudioPlayer : MonoBehaviour {
	public delegate void ClickAction();
	public static event ClickAction onClicked;
	// Use this for initialization
	private float LastPissTime = 0.0f;
	private AudioSource thisAS;
	void Start () {
		thisAS = GetComponent<AudioSource> () as AudioSource;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void playSound(){
		if (!thisAS.isPlaying) {
			thisAS.Play ();
		}
		LastPissTime = Time.time;
	}
	void FixedUpdate(){
		if (LastPissTime + 0.2f < Time.time) {
			thisAS.Pause ();
			Debug.Log ("PAUSING NOISE");
		}
	}
}
