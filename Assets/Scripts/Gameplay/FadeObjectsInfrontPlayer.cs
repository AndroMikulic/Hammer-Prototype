using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObjectsInfrontPlayer : MonoBehaviour {

	// Use this for initialization
	int layerMask;
	RaycastHit[] hits;
	float rayDistance = 200.0f;
	public Transform player;
	List<GameObject> transparentObjects;
	float distanceToPlayer;
	float distanceToStructure;
	void Start () {
		transparentObjects = new List<GameObject>();
		layerMask = LayerMask.GetMask("Player", "Structure");
	}
	
	void Update () {
		hits = Physics.RaycastAll(transform.position, (player.position - transform.position), rayDistance, layerMask);
		foreach(RaycastHit hit in hits){
			if(hit.transform.tag.Equals("Player")){
				distanceToPlayer = Vector3.Distance(transform.position, hit.transform.position);
					break;
			}
		}
		foreach(RaycastHit hit in hits){
			if(hit.transform.tag.Equals("Structure")){
				distanceToStructure = Vector3.Distance(transform.position, hit.point);
				if(distanceToPlayer > distanceToStructure){
					hit.transform.gameObject.GetComponent<StructureScript>().hitByRay = true;
				}
			}
		}
	}
}
