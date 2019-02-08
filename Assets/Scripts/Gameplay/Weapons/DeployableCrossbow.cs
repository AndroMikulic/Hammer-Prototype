using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployableCrossbow : MonoBehaviour {

	public Animation anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			StartCoroutine(FireArrow());
		}
	}

	IEnumerator FireArrow(){
		anim["fire"].speed = 3f;
		anim.Play();
		yield return new WaitForSeconds(anim["fire"].length / 3f + 0.5f);
		anim["fire"].speed = -0.25f;
		anim["fire"].time = anim["fire"].length;
		anim.Play();
		yield return new WaitForEndOfFrame();
	}
}
