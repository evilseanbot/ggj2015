using UnityEngine;
using System.Collections;

public class Trooper : MonoBehaviour {

	public GameObject grid;
	public string state;
	bool panic;
	bool inShelter;
	public float stateTimeLeft;
	bool isWalking;
	GameObject weather;
	public int [] location = new int[3];

	// Use this for initialization
	void Start () {
		state = "waiting";
		stateTimeLeft = 15;
		isWalking = false;
		weather = GameObject.Find ("Weather");
		grid = GameObject.Find ("Grid");
		panic = false;
	}
	
	// Update is called once per frame
	void Update () {

		float speed;

		if (panic) {
		    speed = 0.01f;
		} else {
			speed = 0.002f;
		};

		if (state == "waiting") {
		}

		if (state == "moveLeft") {
			transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
		}
		if (state == "moveDown") {
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
		}
		if (state == "moveRight") {
			transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
		}
		if (state == "moveUp") {
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
		}

		stateTimeLeft -= 1;
		
		if (stateTimeLeft <= 0) {
			pickNewState();
		}

	}

	void hackyFixLocation() {
		for (int i = 0; i < 3; i++) {
			if (location[i] < 0) {
				location[i] = 0;
			}
			if (location[i] > 19) {
				location[i] = 19;
			}
		}
	}

	void pickNewState() {

		// Change the location after a full movement cycle
		if (state == "moveRight") {
			location[0] += 1;
		} else if (state == "moveDown") {
			location[2] -= 1; 
		} else if (state == "moveLeft") {
			location[0] -= 1;
		} else if (state == "moveUp") {
			location[2] += 1;
		}

		hackyFixLocation ();

		// Decide if you should stop or start walking.
		if (isWalking) {
			float shouldStop = Random.Range (0, 5);
			if (shouldStop < 1) {
				state = "waiting";
				isWalking = false;
			} else {
				isWalking = true;
			}
		} else {
			float shouldStartWalking = Random.Range (0, 5);
			if (shouldStartWalking < 1) {
				isWalking = true;
			} else {
				state = "waiting";
				isWalking = true;
			}

		}

		// Always run if panicing
		if (panic) {
			isWalking = true;
		}

		// Always wait if sheltering from the rain
		if (inShelter) {
			isWalking = false;
			state = "waiting";
		}

		// Decide whether to turn. 
		if (isWalking) {
			float shouldChangeDirection = Random.Range (0, 5);

			// If you start walking, you must change direction.
			if (state == "waiting") {
				shouldChangeDirection = 0;
			}

			if (shouldChangeDirection < 1) {
				float shouldMoveTowardsGoal = Random.Range (0, 2);
				if (shouldMoveTowardsGoal < 1) {
					float whatDirectionToMove = Random.Range (0, 2);
					if (whatDirectionToMove < 1) {
						if (transform.position.x > 0) {
							state = "moveLeft";
						} else {
							state = "moveRight";
						}
					} else {
						if (transform.position.z < -9.33f) {
							state = "moveUp";
						} else {
							state = "moveDown";
						}
					}

				} else {
					float whatDirectionToMove = Random.Range (0, 5);
					if (whatDirectionToMove < 1) {
						state = "moveUp";
					} else if (whatDirectionToMove < 2) {
						state = "moveRight";
					} else if (whatDirectionToMove < 3) {
						state = "moveDown";
					} else if (whatDirectionToMove < 4) {
						state = "moveLeft";
					}
				}
			}
		}

		// Adjust direction based on movement

		if (state == "moveUp") {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
		}

		if (state == "moveRight") {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 90, 0));
		}

		if (state == "moveDown") {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 180, 0));
		}

		if (state == "moveLeft") {
			transform.rotation = Quaternion.Euler (new Vector3 (0,270, 0));
		}

		// If at an edge, stop if normal, if panicing, be removed.
		if (state == "moveUp" && location[2] >= 19) {
			isWalking = false;
			state = "waiting";

			if (panic) {
				Destroy (gameObject);
			}
		}
		if (state == "moveRight" && location[0] >= 19) {
			isWalking = false;
			state = "waiting";

			if (panic) {
				Destroy (gameObject);
			}

		}
		if (state == "moveDown" && location[2] <= 0) {
			isWalking = false;
			state = "waiting";

			if (panic) {
				Destroy (gameObject);
			}
		}
		if (state == "moveLeft" && location[0] <= 0) {
			isWalking = false;
			state = "waiting";

			if (panic) {
				Destroy (gameObject);
			}
		}

		/*// Prevent moving in to blocks
		if (state == "moveUp" && location[2] >= 19) {
			isWalking = false;
			state = "waiting";			
		}
		if (state == "moveRight" && location[0] >= 19) {
			isWalking = false;
			state = "waiting";
		}
		if (state == "moveDown" && location[2] <= 0) {
			isWalking = false;
			state = "waiting";
		}
		if (state == "moveLeft" && location[0] <= 0) {
			isWalking = false;
			state = "waiting";			
		}*/


		if (weather.GetComponent<Weather>().isRaining) {

			if (grid.GetComponent<Grid>().shelterGrid[location[0], location[1], location[2]] == 1) {
				inShelter = true;
				panic = false;
			} else {
				panic = true;
				inShelter = false;
			}
		} else {
			panic = false;
			inShelter = false;
		}



		if (panic) {
			stateTimeLeft = 3;
		} else {
		    stateTimeLeft = 15;
		}
	}
}
