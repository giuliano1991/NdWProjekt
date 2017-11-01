using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSounds : MonoBehaviour {

	public AudioClip[] clipFX;
	public AudioSource ElevatorsourceFX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ElevatorMoving() {

		PlaySoundFX (0);
		ElevatorsourceFX.loop = true;
	
	}

	public void ElevatorStopping() {
		
		ElevatorsourceFX.loop = false;
		StopSoundFX (0);
		PlaySoundFX (1);
	
	}

	public void ElevatorFalling() {

		ElevatorsourceFX.loop = true;
		PlaySoundFX (2);
	
	}

	public void ElevatorChrashing() {

		ElevatorsourceFX.loop = false;
		StopSoundFX (2);
		PlaySoundFX (3);
	
	}

	void PlaySoundFX (int clip) {

		ElevatorsourceFX.clip = clipFX [clip];
		ElevatorsourceFX.Play();

	}

	void StopSoundFX (int clip) {
	
		ElevatorsourceFX.clip = clipFX [clip];
		ElevatorsourceFX.Stop ();

	}
}
