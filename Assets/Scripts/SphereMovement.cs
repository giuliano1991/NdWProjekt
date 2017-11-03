using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{

	public Vector3 velocityVector;
	public bool triggerOnlyOnce;
	private bool useTrigger = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

		if (other.gameObject.name == "Sphere" && useTrigger == true) {

			other.GetComponent<Rigidbody> ().velocity = new Vector3(0,0,0);
			other.GetComponent<Rigidbody> ().velocity = velocityVector;

			if (triggerOnlyOnce == true) {

				useTrigger = false;
		
			}
		}

    }

	public void ResetTrigger () {
	
		useTrigger = true;

	}
		
}
