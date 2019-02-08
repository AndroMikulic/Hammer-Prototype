using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public GameObject gameManager;
	public GameObject player;
	public GameObject objective;
	public Rigidbody rigidbody;
	public UnityEngine.AI.NavMeshAgent agent;
	public float destructionTimer;
	public GameObject scoreboard;
	public bool hit = false;
	AudioSource audioSource;
	

    void Start(){
		rigidbody = GetComponent<Rigidbody>();
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		audioSource = GetComponent<AudioSource>();
	}

	void Update(){
		if(agent.enabled == true && objective != null){
			agent.SetDestination(objective.transform.position);
		}		
	}
	void OnTriggerEnter(Collider collider){
		GameOver gameOverHandler = gameManager.GetComponent<GameOver>();
		if(collider.tag.Equals("Objective")){
			if(!gameOverHandler.isGameOver){
				gameOverHandler.InitiateGameOver();
			}
		}
	}

	public IEnumerator Destroyer(){
		yield return new WaitForSeconds(destructionTimer);
		Destroy(gameObject);
	}
}
