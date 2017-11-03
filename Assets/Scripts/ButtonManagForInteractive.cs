using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagForInteractive : MonoBehaviour {

	public void LoadMainMenu() {

		StartCoroutine (UnloadScene("GameScene"));
		SceneManager.LoadScene("GameScene");

	}

	IEnumerator UnloadScene(string unload) {
		yield return new WaitForSeconds (0.1f);
		SceneManag.Instance.Unload (unload);
	}

}
