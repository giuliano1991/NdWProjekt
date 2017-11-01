using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCubeTrigger : MonoBehaviour {

	public RedCube _RedCube;
	public GameObject objectTrigger;
	Collider t_Collider;

	// Use this for initialization
	void Start () {

		t_Collider = GetComponent<Collider> ();

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other) {

		objectTrigger = other.gameObject;
		_RedCube.TriggerFunction (objectTrigger);
		t_Collider.enabled = false;

	}

	public void ActiveTrigger () {

		t_Collider.enabled = true;

	}

	public void DeactiveTrigger () {
	
		t_Collider.enabled = false;

	}
}
