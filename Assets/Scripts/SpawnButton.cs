using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-------------------------------------------------------

public class SpawnButton : MonoBehaviour {

	////////////////////////////
	// Alle Variablen

	// Öffentliche Intvariable für das Defenieren der Position des Cubes (0 = Vorne; 1 = Hinten; 2 = Links; 3 = Rechts)
	public int location = 0;

	// Öffentlicher GameObject zum deklarieren wo die Kugel neu spawnt
	public SpawnLocation _SpawnLocation;

	// Audio
	public AudioSource sourceFX;
	public AudioClip[] clipFX;

	//Licht
	public Light[] LightList;

	// Die Geschwindigkeit des Cubes
	private float speed = 2f;

	// Boolean zum Überprüfen ob der Cube gedrückt wurde und ob das Rätsel gelöst wurde
	private bool isBusy = false;
	private bool riddleSolve = false;

	// Vektoren für From To deklarieren (initialiseren hier oben noch nicht möglich)
	private Vector3 frontToBack;
	private Vector3 backToFront;
	private Vector3 leftToRight;
	private Vector3 rightToLeft;

	// Startposition, Endposition und Distanz
	private Vector3 startPos;
	private Vector3 endPos;
	private float distance = 0.5f;

//-------------------------------------------------------

	////////////////////////////
	// Use this for initialization
	void Start () {

		startPos = transform.position;

		frontToBack = new Vector3(0, 0, -distance);
		backToFront = new Vector3(0, 0, distance);
		leftToRight = new Vector3(distance, 0, 0);
		rightToLeft = new Vector3(-distance, 0, 0);

	}

//-------------------------------------------------------

	////////////////////////////
	// Update is called once per frame
	void Update () {

	}

//-------------------------------------------------------

//////////////////////////////////////////////////////////////////////////////////////////
// ==============
// GAMEPLAY FUNKTIONEN
// ==============
//{///////////////////////////////////////////////////////////////////////////////////////

//-------------------------------------------------------

	////////////////////////////
	// Funktion die die Funktion Spawn im anderen Script auslöst
	public void SpawnButtonPress () {
	
		// Wird geprüft ob der Cube betätigt wurde
		if (isBusy != true) {

			// Wird geprüft ob Rätsel gelöst wurde
			if (riddleSolve == false) {
				
				_SpawnLocation.Spawn ();
				PlaySoundFX (0);
			
			} 

			else {
			
				PlaySoundFX (1);

			}

			// Switchabfrage für die Position des Cubes + die korrekte Berechnung der Animation
			switch (location) {

			case 0: // FrontToBack
				StartCoroutine (Animate (frontToBack));
				break;

			case 1: // BackToFront
				StartCoroutine (Animate (backToFront));
				break;

			case 2: // LeftToRight
				StartCoroutine (Animate (leftToRight));
				break;

			case 3: // RightToLeft
				StartCoroutine (Animate (rightToLeft));
				break;
			}
		} 
	}

//-------------------------------------------------------

	////////////////////////////
	// Funktion der den Boolwert riddleSolve löst
	public void RiddleSolved () {
	
		riddleSolve = true;

		foreach (Light obj in LightList)
			obj.GetComponent<LightManag> ().ChangeLight();

	}

//-------------------------------------------------------

//} ENDE GAMEPLAY FUNKTIONEN

//////////////////////////////////////////////////////////////////////////////////////////
// ==============
// IENUMERATOR / ANIMATION
// ==============
//{///////////////////////////////////////////////////////////////////////////////////////

//-------------------------------------------------------

	////////////////////////////
	// Die Animation des Cubes, der Vektor fromTo gibt an, wo die Animation anfängt / wo sie aufhört
	IEnumerator Animate(Vector3 fromTo)
	{
		// Timer wird auf Null gesetzt und die Startposition und Endposition des Cubes wird ermittelt
		float timeSinceStarted = 0f;
		startPos = transform.position;
		endPos = transform.position + fromTo;

		// Der Timer wird gestartet
		while (timeSinceStarted <= 1f)
		{
			isBusy = true;

			// Die Hinanimation
			if (timeSinceStarted <= 0.5f) {
				timeSinceStarted += Time.deltaTime * speed;
				transform.position = Vector3.Lerp (startPos, endPos, timeSinceStarted);
				yield return null;

			// Die Rückanimation
			} else {
				timeSinceStarted += Time.deltaTime * speed;
				transform.position = Vector3.Lerp (endPos, startPos, timeSinceStarted);
				yield return null;
			}
		}

		// Nachdem der Timer zuende ist, ist der Cube wieder interagierbar und die Kollision ist deaktiviert
		isBusy = false;
		yield return new WaitForSeconds(0.1f);

	}

//-------------------------------------------------------

//} ENDE IENUMERATOR / ANIMATION

//////////////////////////////////////////////////////////////////////////////////////////
// ==============
// AUDIO
// ==============
//{///////////////////////////////////////////////////////////////////////////////////////

//-------------------------------------------------------

	////////////////////////////
	// Die Animation des Cubes, der Vektor fromTo gibt an, wo die Animation anfängt / wo sie aufhört
	void PlaySoundFX (int clip)
	{

		sourceFX.clip = clipFX [clip];
		sourceFX.Play();

	}

//-------------------------------------------------------

//} ENDE AUDIO

}