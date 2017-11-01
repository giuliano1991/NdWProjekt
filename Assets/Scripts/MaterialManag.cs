using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManag : MonoBehaviour {

	private Material firstMat;
	public Material secondMat;
	public float duration;
	public Renderer rend;

	// Use this for initialization
	void Start () {

		rend = GetComponent<Renderer> ();
		firstMat = rend.material;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeMat() {

		StartCoroutine (MatFade());

	}

	IEnumerator MatFade() {

		float timeSinceStarted = 0f;

		while (timeSinceStarted <= 1f) {

			timeSinceStarted += Time.deltaTime / duration;
			rend.material.Lerp(firstMat, secondMat, timeSinceStarted);
			yield return null;
		}

		yield return new WaitForSeconds(0.1f);
	}
}
