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

		leftController.GetComponent<MenuToggle>().enabled = true;
		rightController.GetComponent<MenuToggle>().enabled = true;

	}

	public void DeactiveMenuFollower() {

		leftController.GetComponent<MenuToggle>().enabled = false;
		rightController.GetComponent<MenuToggle>().enabled = false;

	}

}
