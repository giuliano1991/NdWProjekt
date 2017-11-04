using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour {

	// Variablen für die Button Animation
	private Vector3 startPos;
	private Vector3 endPos;
	private Vector3 leftToRight;
	private float distance = 0.5f;
	private bool ButtonUsed = false;
	public TriggerPlayer _TriggerPlayer;

	// Variablen für den Aufzug Animation
	public GameObject ElevatorShaft;
	public GameObject ElevatorStop;
	private Vector3 elevatorStartPos;
	private Vector3 elevatorStopPos;
	public AudioSource ElevatorMusic;
	public GameObject noEscapeBox;

	//Variablen für den Absturz Animation
	private Vector3 BlackOut;

	//Light
	public LightManag _LightBtn;
	public LightManag _LightEle;
	public LightManag _LightRed;
	public LightManag _LightRed2;
	public LightManag _LightRed3;
	public LightManag _LightRed4;

	//Material
	public MaterialManag _MatEle;
	public MaterialManag _MatRed;
	public MaterialManag _MatRed2;
	public MaterialManag _MatRed3;
	public MaterialManag _MatRed4;
	public Material blacksky;

	// Audio
	public AudioSource sourceFX;
	public ElevatorSounds _elevatorSounds;

	// Variablen für die Tür Animation
	public Door _DoorClos;
	public string unloadName;
	public string unloadConnecter;

	// Use this for initialization
	void Start () {

		startPos = transform.position;
		elevatorStartPos = ElevatorShaft.transform.position;
		elevatorStopPos = ElevatorStop.transform.position;
		leftToRight = new Vector3(distance, 0, 0);
		BlackOut = new Vector3 (10f, 76.8f, 17f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonPress () {

		if (ButtonUsed != true /*&& _TriggerPlayer.isFacing != false*/ ) {
		sourceFX.Play ();
		StartCoroutine (AnimateButton());
		noEscapeBox.SetActive (true);

		}
	}

	private void LightsOff() {
	
		_LightBtn.ChangeLight ();
		_LightEle.ChangeLight ();
		_MatEle.ChangeMat ();
		RenderSettings.ambientIntensity = 0.1f;
		RenderSettings.reflectionIntensity = 0.1f;
		RenderSettings.skybox = blacksky;
	
	}

	private void LightsOn() {

		_LightRed.ChangeLight();
		_MatRed.ChangeMat ();
		_LightRed2.ChangeLight();
		_MatRed2.ChangeMat ();
		_LightRed3.ChangeLight();
		_MatRed3.ChangeMat ();
		_LightRed4.ChangeLight();
		_MatRed4.ChangeMat ();
		//RenderSettings.ambientIntensity = 0.3f;
	
	}

	IEnumerator AnimateButton()
	{
		// Timer wird auf Null gesetzt und die Startposition und Endposition des Cubes wird ermittelt
		float timeSinceStarted = 0f;
		startPos = transform.position;
		endPos = transform.position + leftToRight;

		// Der Timer wird gestartet
		while (timeSinceStarted <= 1f)
		{
			ButtonUsed = true;

			// Die Hinanimation
			if (timeSinceStarted <= 0.5f) {
				timeSinceStarted += Time.deltaTime * 2f;
				transform.position = Vector3.Lerp (startPos, endPos, timeSinceStarted);
				yield return null;

				// Die Rückanimation
			} else {
				timeSinceStarted += Time.deltaTime * 2f;
				transform.position = Vector3.Lerp (endPos, startPos, timeSinceStarted);
				yield return null;
			}
		}

		StartCoroutine (DoorClose());
		yield return new WaitForSeconds(0.1f);

	}

	IEnumerator DoorClose () {
		_DoorClos.DoorClose ();
		yield return new WaitForSeconds(2.5f);
		if (unloadName != "") {
			StartCoroutine(UnloadScene(unloadName));
		}
		if (unloadConnecter != "") {
			StartCoroutine (UnloadScene (unloadConnecter));
		}

		yield return new WaitForSeconds (0.2f);
		StartCoroutine (ElevatorAnimation());
		yield return new WaitForSeconds (0.1f);

	}

	IEnumerator UnloadScene(string unload) {
		yield return new WaitForSeconds (0.1f);
		SceneManag.Instance.Unload (unload);
	}

	IEnumerator ElevatorAnimation () {

		// Timer wird auf Null gesetzt und die Startposition und Endposition des Cubes wird ermittelt
		float timeSinceStarted = 0f;
		float ElevatorSpeed = 0f;
		noEscapeBox.SetActive (false);
		_elevatorSounds.ElevatorMoving ();
		yield return new WaitForSeconds (0.6f);
		ElevatorMusic.Play ();

		// Der Timer wird gestartet
		while (timeSinceStarted <= 27f)
		{
				timeSinceStarted += Time.deltaTime;
				ElevatorSpeed += Time.deltaTime * 1.8f;
				ElevatorShaft.transform.position = Vector3.MoveTowards(elevatorStartPos, elevatorStopPos, ElevatorSpeed);
				yield return null;
		}
		StartCoroutine (ElevatorStops());
		yield return new WaitForSeconds (0.1f);
	}

	IEnumerator ElevatorStops() {

		ElevatorMusic.Stop();
		_elevatorSounds.ElevatorStopping ();
		LightsOff ();
		yield return new WaitForSeconds (2.5f);
		LightsOn();
		yield return new WaitForSeconds (6.5f);
		// Timer wird auf Null gesetzt und die Startposition und Endposition des Cubes wird ermittelt
		float timeSinceStarted = 0f;
		float ElevatorSpeed = 0f;
		float speedMulti = 0f;
		bool startSound = false;
		bool startFade = false;
		elevatorStartPos = ElevatorShaft.transform.position;

		// Der Timer wird gestartet
		while (timeSinceStarted <= 9f)
		//while (ElevatorShaft.transform.position != BlackOut)
		{
			timeSinceStarted += Time.deltaTime;
			if (startSound == false) {
				_elevatorSounds.ElevatorFalling ();
				startSound = true;
			}

			if (timeSinceStarted >= 8.3f && startFade == false) {

				FadeManag.Instance.Fade ();
				startFade = true;
			
			}

			if (speedMulti <= 9f) {

				ElevatorSpeed += Time.deltaTime * speedMulti;
				speedMulti += Time.deltaTime *2.2f;
			
			} else {
				
				ElevatorSpeed += Time.deltaTime * 9;
			
			}
			ElevatorShaft.transform.position = Vector3.MoveTowards(elevatorStartPos, BlackOut, ElevatorSpeed);
			yield return null;
		}
		//_elevatorSounds.ElevatorChrashing();

		yield return new WaitForSeconds (8f);

        StartCoroutine(UnloadScene("GameScene"));

        SceneManager.LoadScene("GameScene");

    }
}
