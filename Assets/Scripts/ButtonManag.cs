using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManag : MonoBehaviour {

	public string unloadOutro;

	public void NewGame(string newGameLevel) {

		SceneManager.LoadScene (newGameLevel);

	}

	public void ExitGame() {
	
		Application.Quit ();

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
