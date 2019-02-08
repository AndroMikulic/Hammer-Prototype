using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public int score = 0;
	public Text scoreLabel;
	Animation animation;
	string bumpAnimation = "ScoreScaleBump";
	void Start(){
		animation = GetComponent<Animation>();
	}
	public void AddScore(){
		score++;
		scoreLabel.text = score.ToString();
		animation.PlayQueued(bumpAnimation, QueueMode.CompleteOthers);
	}
}
