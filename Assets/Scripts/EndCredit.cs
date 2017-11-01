using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCredit : MonoBehaviour {

	public string loadName;
	public string unloadName;
	public string unloadConnecter;

	public FadeManag _FadeManag;
	public FadeManag _FadeManag2;
	private float duration = 10f;
	private bool startSequenz = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (startSequenz == true) {
			startSequenz = false;
			StartCoroutine (Sequenz ());
		}
	}

	IEnumerator Sequenz() {
	

		if (unloadName != "") {
			StartCoroutine(UnloadScene(unloadName));
		}

		if (unloadConnecter != "") {
			StartCoroutine (UnloadScene (unloadConnecter));
		}
		yield return new WaitForSeconds (3f);

		_FadeManag.Fade ();

		yield return new WaitForSeconds (duration);

		_FadeManag2.Fade ();

		yield return new WaitForSeconds (8f);

		if (loadName != "") {
			SceneManag.Instance.Load (loadName);
		}

	}

	IEnumerator UnloadScene(string unload) {
		yield return new WaitForSeconds (0.1f);
		SceneManag.Instance.Unload (unload);
	}
}
