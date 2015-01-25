using UnityEngine;
using System.Collections;

public class TrooperSpawner : MonoBehaviour {

	int timeToSpawn;
	public GameObject trooper;

	// Use this for initialization
	void Start () {
		timeToSpawn = 120;
	}
	
	// Update is called once per frame
	void Update () {
		timeToSpawn -= 1;
		if (timeToSpawn == 0) {
			spawn();
			timeToSpawn = 240;
		}
	}

	void spawn() {
		float spawnEdge = Random.Range (0, 2);
		if (spawnEdge < 1) {
			int spawnX = (int) Random.Range (0, 20);
			GameObject myTrooper = Instantiate (trooper, new Vector3 (( (float)spawnX * 0.03f) - 0.33f, 0, -9), transform.rotation) as GameObject;
			myTrooper.GetComponent<Trooper>().location = new int[3] {spawnX, 0, 19};
		} else if (spawnEdge < 2) {
			int spawnX = (int) Random.Range (0, 20);
			GameObject myTrooper = Instantiate (trooper, new Vector3 (( (float)spawnX * 0.03f) - 0.33f, 0, -9.66f), transform.rotation) as GameObject;
			myTrooper.GetComponent<Trooper>().location = new int[3] {spawnX, 0, 0};

		}
	}
}
