using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject gameManager;
	public float enemiesPerSecond;
	public int waveCount;
	public float waveDealy;
	public GameObject enemyPrefab;
	public GameObject allEnemies;
	public GameObject player;
	public GameObject objective;
	public GameObject scoreboard;
	void Start(){
		StartCoroutine(Spawner());
	}

	IEnumerator Spawner(){
		int cnt = 0;
		while(true){
			GameObject clone = Instantiate(enemyPrefab, transform.position, transform.rotation);
			clone.transform.parent = allEnemies.transform;
			clone.GetComponent<EnemyScript>().objective = this.objective;
			clone.GetComponent<EnemyScript>().player = this.player;
			clone.GetComponent<EnemyScript>().scoreboard = this.scoreboard;
			clone.GetComponent<EnemyScript>().gameManager = this.gameManager;
			cnt++;
			if(cnt == waveCount){
				cnt = 0;
				yield return new WaitForSeconds(waveDealy);
			}else{
				yield return new WaitForSeconds(1.0f / enemiesPerSecond);
			}
		}
	}
}
