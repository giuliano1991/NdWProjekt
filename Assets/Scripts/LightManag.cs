using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManag : MonoBehaviour {

	public float duration = 1f;
	private float intenStart;
	public float intenEnd;
	private Light lt;

	// Use this for initialization
	void Start () {

		lt = GetComponent<Light> ();
		intenStart = lt.GetComponent<Light> ().intensity;

	}

	public void ChangeLight() {
	
		StartCoroutine (LightFade());

	}

	IEnumerator LightFade() {
	
		float timeSinceStarted = 0f;

		while (timeSinceStarted <= 1f) {
		
			timeSinceStarted += Time.deltaTime / duration;
			lt.intensity = Mathf.Lerp(intenStart, intenEnd, timeSinceStarted);
			yield return null;
		}

		yield return new WaitForSeconds(0.1f);
	}
}
