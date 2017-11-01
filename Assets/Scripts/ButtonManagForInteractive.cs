using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagForInteractive : MonoBehaviour {

	public string unloadOutro;

	public void LoadMainMenu() {

		// hier Main Menu Szene laden

	}

	void Start () {
	
		if (unloadOutro != "") {

			StartCoroutine (UnloadScene (unloadOutro));

		}

	}

	IEnumerator UnloadScene(string unload) {
		yield return new WaitForSeconds (0.1f);
		SceneManag.Instance.Unload (unload);
	}

}
