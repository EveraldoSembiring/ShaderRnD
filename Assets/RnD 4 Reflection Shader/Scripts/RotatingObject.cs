using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-2,2), Random.Range(-2, 2), Random.Range(-2, 2)));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
