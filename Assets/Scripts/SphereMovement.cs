using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{

    public float value = 0;
    public GameObject prefab;
	bool TriggerFirstUsed = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

   /* void OnCollisionEnter (Collision col)
	{

		prefab.GetComponent<Rigidbody> ().angularDrag = value;

	}*/

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Sphere")
        {
			TriggerFunktion ();
        }

    }

	void TriggerFunktion() {

		if (TriggerFirstUsed == true) {
		//prefab.GetComponent<Rigidbody>().angularDrag = value;
		TriggerFirstUsed = false;
		prefab.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		}
	}

	public void TriggerReset() {

		TriggerFirstUsed = true;
	}
}
