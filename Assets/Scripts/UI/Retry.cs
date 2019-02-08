using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retry : MonoBehaviour {

	// Use this for initialization
	public void OnClick(){
		Application.LoadLevel(Application.loadedLevel);
	}
}
