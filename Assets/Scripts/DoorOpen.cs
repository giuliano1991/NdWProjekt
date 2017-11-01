using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

	public Door _Door;
	public Door _DoorClos;
	public GameObject prefab;
	public AudioSource sourceFX;
	public SpawnButton _SpawnButton;
	public bool closedoorfirst = false;
	public string loadName;
	public string unloadName;
	public string loadConnecter;
	public string unloadConnecter;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.name == "Sphere") {
        Destroy(prefab);
        sourceFX.Play();
		_SpawnButton.RiddleSolved ();

			if (closedoorfirst == true) {
				StartCoroutine (Delay ());
			}
			else _Door.DoorOpen();
   		}
	}

	IEnumerator Delay () {
		_DoorClos.DoorClose ();
		yield return new WaitForSeconds(2.5f);
		if (unloadName != "") {
			StartCoroutine(UnloadScene(unloadName));
		}
		if (unloadConnecter != "") {
			StartCoroutine (UnloadScene (unloadConnecter));
		}
		if (loadName != "") {
			SceneManag.Instance.Load (loadName);
		}
		if (loadConnecter != "") {
			SceneManag.Instance.Load (loadConnecter);
		}
		yield return new WaitForSeconds (0.1f);
		_Door.DoorOpen ();
	}

	IEnumerator UnloadScene(string unload) {
		yield return new WaitForSeconds (0.1f);
		SceneManag.Instance.Unload (unload);
	}
}
