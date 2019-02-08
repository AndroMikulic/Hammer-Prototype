using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public bool boosted = false;
	public float arrowSpeed = 10.0f;
	// Update is called once per frame
	void Update () {
		if(!boosted && GetComponent<Rigidbody>().velocity.magnitude > 1){
			boosted = true;
			transform.parent = null;
			GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * arrowSpeed;
		}
	}
}
