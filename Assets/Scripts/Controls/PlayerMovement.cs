using UnityEngine;
using System.Collections; 
public class PlayerMovement : MonoBehaviour {
 
	public float speed = 1.0f;
	float x;
	float z;
	public Vector3 direction;
	public float gravity;

	CharacterController controller;
	
	void Start(){
		controller = GetComponent<CharacterController>();
		
	}
	void FixedUpdate(){
		x = Input.GetAxisRaw("Horizontal");
		z = Input.GetAxisRaw("Vertical");
		if(controller.isGrounded){
			gravity = 0;
		}else{
			gravity = -10;
		}
		direction = new Vector3(x, 0, z);
		direction = Vector3.Normalize(direction);
		direction.y = gravity;
		controller.Move(direction * speed);
	}
}