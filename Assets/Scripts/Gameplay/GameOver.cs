using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public GameObject[] UIs;
	public GameObject gameOverUI;
	public GameObject player;
	public GameObject[] spawners;
	public GameObject allEnemies;

	public bool isGameOver = false;
	public void InitiateGameOver(){
		DisablePlayerControls();
		DisableSpawners();
		KillAllEnemies();
		SwitchUIs();
	}

    private void DisablePlayerControls()
    {
        foreach(MonoBehaviour script in player.GetComponent<PlayerScripts>().scripts){
			script.enabled = false;
		}
    }

	private void SwitchUIs()
    {
        foreach(GameObject ui in UIs){
			ui.SetActive(false);
		}
		gameOverUI.SetActive(true);
    }

	private void DisableSpawners()
    {
        foreach(GameObject spawner in spawners){
			spawner.SetActive(false);
		}
    }

	private void KillAllEnemies()
    {
		EnemyScript[] enemies = allEnemies.GetComponentsInChildren<EnemyScript>();
        foreach(EnemyScript enemy in enemies){
			if(!enemy.hit){
				enemy.agent.enabled = false;
				enemy.rigidbody.isKinematic = false;
				enemy.GetComponent<CapsuleCollider>().isTrigger = false;
				float x = UnityEngine.Random.Range(-0.2f, 0.2f);
				Vector3 randomForce = new Vector3(x, 0, 0);
				enemy.rigidbody.velocity = randomForce;
			}
		}
    }
}