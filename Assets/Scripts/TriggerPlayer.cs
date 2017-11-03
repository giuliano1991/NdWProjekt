using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayer : MonoBehaviour {

	public bool isFacing = false;
	public string canvasName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.name == canvasName) {
			
			isFacing = true;
			Debug.Log ("Im Over the Trigger");

		}

	}

	void OnTriggerExit(Collider other) {
	
		if (other.name == canvasName) {
		
			isFacing = false;
			Debug.Log ("Im not more Over the Trigger");

		}
	
	}
}
