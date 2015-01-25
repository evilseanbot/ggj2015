using UnityEngine;
using System.Collections;

public class Slideshow : MonoBehaviour {

	int timeToMove;

	// Use this for initialization
	void Start () {
		timeToMove = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeToMove > 0) {
			timeToMove -= 1;

			transform.position = new Vector3(transform.position.x-0.2f, transform.position.y, transform.position.z);

		} else {
			if (Input.anyKeyDown) {
				timeToMove = 70;
			}

			if (transform.position.x < -100) {
				Application.LoadLevel("seanna_scene");
			}
		}
	}
}
