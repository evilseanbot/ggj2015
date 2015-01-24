using UnityEngine;
using System.Collections;

public class Builder : MonoBehaviour {

	public GameObject buildingBlock;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("d")) {
			transform.position = new Vector3(transform.position.x+0.03f, transform.position.y, transform.position.z);
		}

		if (Input.GetKeyDown("s")) {
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z-0.03f);
		}

		if (Input.GetKeyDown("a")) {
			transform.position = new Vector3(transform.position.x-0.03f, transform.position.y, transform.position.z);
		}

		if (Input.GetKeyDown("w")) {
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+0.03f);
		}

		if (Input.GetKeyDown("e")) {
			transform.position = new Vector3(transform.position.x, transform.position.y+0.03f, transform.position.z);
		}

		if (Input.GetKeyDown("q")) {
			transform.position = new Vector3(transform.position.x, transform.position.y-0.03f, transform.position.z);
		}

		if (Input.GetKeyDown ("z")) {
			Instantiate (buildingBlock, transform.position, transform.rotation);
		}
	}
}
