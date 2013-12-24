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
	float SHIP_MAX_SPEED = 10f;
	//the current speed of the ship
	float SHIP_SPEED = 4f;
	//how fast does this ship accelerate?
	float SHIP_ACCELERATION = 0.1f;
	//how fast can it rotate
	float SHIP_AGILITY = 5f;

	// should there be constant movement

	float speed = SHIP_START_SPEED;
	float turn_speed = SHIP_AGILITY;

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

	
	// Update is called once per frame
	void Update () {

		float rotationX = 0;
		float rotationY = 0;
		float rotationZ = 0;



		if(Input.GetKey(KeyCode.W)){
			//increase velocity
			SHIP_SPEED = SHIP_SPEED + (SHIP_ACCELERATION * Time.deltaTime);
			if(SHIP_SPEED > SHIP_MAX_SPEED)
				SHIP_SPEED = SHIP_MAX_SPEED;
		}
		else if (Input.GetKey (KeyCode.S)) {
			//decrease acceleration
			SHIP_SPEED = SHIP_SPEED - (SHIP_ACCELERATION * Time.deltaTime);
			if(SHIP_SPEED < 0)
				SHIP_SPEED = 0;
		}

		/*
		 * ROLL
		 */

		if (Input.GetKey (KeyCode.A)) {
			// around the z access
			rotationZ = Input.GetAxis ("Mouse X") * SHIP_AGILITY;
		}
		else if (Input.GetKey (KeyCode.D)) {
			rotationZ = -(Input.GetAxis ("Mouse X") * SHIP_AGILITY);
		}

		/*
		 * PITCH
		 */
		if (Input.GetAxis ("Mouse Y") > 0) {
			rotationY = Input.GetAxis ("Mouse Y") * SHIP_AGILITY;
		} else if (Input.GetAxis ("Mouse Y") < 0) {
			rotationY = -(Input.GetAxis ("Mouse Y") * SHIP_AGILITY);
		}

		/*
		 * YAW
		 */
		if (Input.GetAxis ("Mouse X") > 0) {
			rotationX = Input.GetAxis ("Mouse X") * SHIP_AGILITY;
		} else if (Input.GetAxis ("Mouse X") < 0) {
			rotationX = -(Input.GetAxis ("Mouse X") * SHIP_AGILITY);
		}


		// don't think this is right atm
		// I need to update everything AFTER checking on rotation
		transform.Translate (Vector3.forward * SHIP_SPEED);
		transform.Rotate (rotationX, rotationY, rotationZ);
	}
}
