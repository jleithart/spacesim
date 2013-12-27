using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}

	/*
	 * these two variables will be determined based on the ship chosen
	 */

	//the fastest the ship can go
	float SHIP_MAX_SPEED = 200.0f;
	//the slowest the ship can go
	public float AMBIENT_SPEED = 100.0f;
	//the current speed of the ship
	//float SHIP_SPEED = .1f;
	//how fast does this ship accelerate?
	float SHIP_ACCELERATION = 10.0f;
	//how fast can it rotate
	float SHIP_AGILITY = 200.0f;

	/*
	 * 
	 * Keyboard events:
	 * 		W: 			Accelerate
	 * 		S: 			Decelerate
	 * 		A: 			(+) roll left
	 * 		D: 			(-) roll right
	 * 		Mouse Up:	(+) pitch up
	 * 		Mouse Down:	(-) pitch down
	 * 		Mouse R:	(+) yaw right
	 * 		Mouse L: 	(-) yaw left
	 */ 

	void FixedUpdate(){
		Quaternion AddRot = Quaternion.identity;
		float roll = 0f;
		float pitch = 0f;
		float yaw = 0f;

		roll = Input.GetAxis ("Roll") * (Time.fixedDeltaTime * SHIP_AGILITY);
		pitch = Input.GetAxis ("Pitch") * (Time.fixedDeltaTime * SHIP_AGILITY);
		yaw = Input.GetAxis ("Yaw") * (Time.fixedDeltaTime * SHIP_AGILITY);

		AddRot.eulerAngles = new Vector3 (roll, yaw, pitch);
		rigidbody.rotation *= AddRot;

		Vector3 AddPos = Vector3.forward;
		//AddPos = rigidbody.rotation * AddPos;
		rigidbody.velocity = AddPos * (Time.fixedDeltaTime * AMBIENT_SPEED);}
	
}
