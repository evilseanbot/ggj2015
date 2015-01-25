using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public int [,,] shelterGrid;
	public int [,,] blockGrid;


	// Use this for initialization
	void Start () {
		shelterGrid = new int[20, 20, 20];
		blockGrid = new int[20, 20, 20];

		for (int x = 0; x < 20; x++) {
			for (int y = 0; y < 20; y++) {
				for (int z = 0; z < 20; z++) {
					shelterGrid[x, y, z] = 0;
					blockGrid[z,y,z] = 0;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
