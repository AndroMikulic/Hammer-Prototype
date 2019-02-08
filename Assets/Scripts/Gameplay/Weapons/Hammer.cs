using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {

	AudioSource audioSource;
	public GameObject scoreboard;
	public AudioClip[] hitClips;
	public float forceFactor;
	public float torque;

	void Start(){
		audioSource = GetComponent<AudioSource>();
	}
	void OnTriggerEnter(Collider collider){
		if(collider.tag.Equals("Enemy")){
			EnemyScript enemy = collider.GetComponent<EnemyScript>();
			if(!enemy.hit){
				enemy.hit = true;
				enemy.agent.enabled = false;
				enemy.rigidbody.isKinematic = false;
				enemy.GetComponent<CapsuleCollider>().isTrigger = false;
				audioSource.PlayOneShot(hitClips[Random.Range(0, hitClips.Length)]);
				Rigidbody hamemrRigidbody = GetComponent<Rigidbody>();
				Vector3 force = Vector3.Normalize(hamemrRigidbody.velocity);
				force.y = Random.Range(0.5f, 1.0f);
				force *= forceFactor;
				enemy.rigidbody.AddForce(force, ForceMode.Impulse);
				enemy.rigidbody.AddTorque(transform.right * torque, ForceMode.Impulse);
				scoreboard.GetComponent<ScoreScript>().AddScore();
				StartCoroutine(enemy.Destroyer());
			}
		}
	}
}
