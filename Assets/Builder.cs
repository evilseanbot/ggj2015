using UnityEngine;
using System.Collections;

public class Builder : MonoBehaviour {

	public GameObject buildingBlock;
	public GameObject grid;
	private int [] location; 

	// Use this for initialization
	void Start () {
		location = new int[]{10, 0, 10}; 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("d")) {
			if (location[0] < 19) {
				transform.position = new Vector3(transform.position.x+0.03f, transform.position.y, transform.position.z);
				location[0]+=1;
			}
		}

		if (Input.GetKeyDown("s")) {
			if (location[2] > 0) {
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z-0.03f);
				location[2]-=1;
			}
		}

		if (Input.GetKeyDown("a")) {
			if (location[0] > 0) {
				transform.position = new Vector3(transform.position.x-0.03f, transform.position.y, transform.position.z);
				location[0]-=1;
			}
		}

		if (Input.GetKeyDown("w")) {
			if (location[2] < 19) {
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+0.03f);
				location[2]+=1;
			}
		}

		if (Input.GetKeyDown("e")) {
			if (location[1] < 19) {
				transform.position = new Vector3(transform.position.x, transform.position.y+0.03f, transform.position.z);
				location[1]+=1;
			}
		}

		if (Input.GetKeyDown("q")) {
			if (location[1] > 0) {
				transform.position = new Vector3(transform.position.x, transform.position.y-0.03f, transform.position.z);
				location[1]-=1;
			}
		}

		if (Input.GetKeyDown ("z")) {
			buildBlock();
		}

		if (Input.GetKeyDown ("x")) {
			deleteBlock();
		}

		/*if (grid.GetComponent<Grid> ().shelterGrid [location [0], location [1], location [2]] == 1) {
			Debug.Log ("In shelter");
		}*/
	}

	void deleteBlock() {
		GameObject obj = GameObject.Find ("Block" + location [0] + "x" + location [1] + "x" + location [2]);
		Destroy (obj);

		bool sheltered = false;

		grid.GetComponent<Grid>().blockGrid[location[0], location[1], location[2]] = 0;

		for (int i = 19; i > -1; i--) {
			if (sheltered) {
				grid.GetComponent<Grid>().shelterGrid[location[0], i, location[2]] = 1;
			} else {
				grid.GetComponent<Grid>().shelterGrid[location[0], i, location[2]] = 0;
			}

			if (grid.GetComponent<Grid>().blockGrid[location[0], i, location[2]] == 1) {
				sheltered = true;
			}
		}
	}

	void buildBlock() {
		GameObject obj = Instantiate (buildingBlock, transform.position, transform.rotation) as GameObject;
		obj.name = "Block"+location[0]+"x"+location[1]+"x"+location[2];

		grid.GetComponent<Grid>().blockGrid[location[0], location[1], location[2]] = 1;

		// Make every block below this shelter,
		for (int i = location[1]-1; i > -1; i--) {
			grid.GetComponent<Grid>().shelterGrid[location[0], i, location[2]] = 1;
		}
	}
}
