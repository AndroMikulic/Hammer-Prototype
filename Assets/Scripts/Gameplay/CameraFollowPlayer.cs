using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

	public Transform player;

	public Vector3 offset;
	Vector3 currentPosition;
	Vector3 playerPosition;

	void LateUpdate()
	{	
		currentPosition = transform.position;
		playerPosition = player.position;
		playerPosition += offset;
		transform.position = playerPosition;
	}
}
