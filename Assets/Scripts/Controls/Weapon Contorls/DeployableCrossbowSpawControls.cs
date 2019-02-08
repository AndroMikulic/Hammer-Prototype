using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployableCrossbowSpawControls : MonoBehaviour {

	public float chargeTime = 3.0f;
	float timer;
	public bool charging = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			charging = true;
		}
	}
}
