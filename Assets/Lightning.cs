using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {

	int timeToGlow;

	// Use this for initialization
	void Start () {
		timeToGlow = 3;
	}
	
	// Update is called once per frame
	void Update () {
		timeToGlow -= 1;
		if (timeToGlow <= 0) {
			light.enabled = false;
		}
	}
}
