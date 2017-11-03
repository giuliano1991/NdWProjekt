using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManag : MonoBehaviour {

	public static SceneManag Instance { set; get;}

	private void Awake () {

		Instance = this;
		Load ("Menu");
		MenuFollowerActive.Instance.DeactiveMenuFollower ();

	}

	public void Load (string sceneName) {

		if (!SceneManager.GetSceneByName(sceneName).isLoaded)
			SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);

	}

	public void Unload(string sceneName) {

		if (SceneManager.GetSceneByName (sceneName).isLoaded)
			SceneManager.UnloadSceneAsync (sceneName);

		if (sceneName == "Menu")
			MenuFollowerActive.Instance.ActiveMenuFollower ();

	}

	// Use this for initialization
	/*void Start () {
		
	Instance = this;
	Load("Player");
	Load("Task_1");
	Load ("Connecter_1");
	Load("Task_2");
	Load("Connecter_2");

	}*/
}
