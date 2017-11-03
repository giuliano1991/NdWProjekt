using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : MonoBehaviour {


	public GameObject[] TriggerResets;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.name == "Sphere") {

			foreach (GameObject obj in TriggerResets)
				obj.GetComponent<SphereMovement> ().ResetTrigger();

		}

	}
}
