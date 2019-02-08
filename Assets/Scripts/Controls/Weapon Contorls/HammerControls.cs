using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerControls : MonoBehaviour {

	public float cooldown = 1.0f;
	bool ready = true;
	public Animator animator;
	public AudioClip[] swingSounds;
	AudioSource audioSource;
	void Start(){
		audioSource = GetComponent<AudioSource>();
	}
	void Update () {
		if(ready && Input.GetMouseButtonDown(0)){
			StartCoroutine(AttackCooldown());
			animator.SetTrigger("attack");
			audioSource.PlayOneShot(swingSounds[Random.Range(0, swingSounds.Length)]);
		}
	}
	IEnumerator AttackCooldown(){
		ready = false;
		yield return new WaitForSeconds(cooldown);
		ready = true;
	}
}