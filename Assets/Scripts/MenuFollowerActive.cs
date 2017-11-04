using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFollowerActive : MonoBehaviour {

	public static MenuFollowerActive Instance { set; get;}

	public GameObject leftController;
	public GameObject rightController;

	// Use this for initialization
	void Start () {

		Instance = this;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ActiveMenuFollower() {

		//leftController.GetComponent<>
		//rightController.GetComponent<VRTK_ControllerEvents_UnityEvents>().enabled = true;

	}

	public void DeactiveMenuFollower() {

		//leftController.GetComponent<VRTK_ControllerEvents_UnityEvents>().enabled = false;
		//rightController.GetComponent<VRTK_ControllerEvents_UnityEvents>().enabled = false;

	}

}
