﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManag : MonoBehaviour {

	public Image fadeImage;
	public float duration;
	public Color secondColor;
	public bool fadeIn;
	private Color firstColor;

	// Use this for initialization
	void Start () {

		firstColor = fadeImage.GetComponent<Image> ().color;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Fade () {
	
		StartCoroutine (FadeTransition());
	
	}

	IEnumerator FadeTransition () {
	
		float transition = 0f;
		fadeImage.enabled = true;

		while (transition <= 1f) {
		
			transition += Time.deltaTime * (1/duration);
			fadeImage.color = Color.Lerp (firstColor, secondColor, transition);
			yield return null;
		
		}

		if (fadeIn == true) {
		
			fadeImage.enabled = false;

		}

		yield return new WaitForSeconds (0.1f);

	}
}