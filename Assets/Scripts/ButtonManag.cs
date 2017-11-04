using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManag : MonoBehaviour {

	public void NewGame() {

		//SceneManag.Instance.Load ("interactiveMenu");
		SceneManag.Instance.Load ("Task_1");
		SceneManag.Instance.Load ("Connecter_1");
		SceneManag.Instance.Load ("Task_2");
		SceneManag.Instance.Load ("Connecter_2");

		StartCoroutine(UnloadScene ("Menu"));

	}

	public void ExitGame() {
	
		Application.Quit ();

	}
		

	IEnumerator UnloadScene(string unload) {
		yield return new WaitForSeconds (0.1f);
		SceneManag.Instance.Unload (unload);
	}

}
