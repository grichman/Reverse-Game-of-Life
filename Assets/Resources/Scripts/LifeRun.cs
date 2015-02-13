using UnityEngine;
using System.Collections;

public class LifeRun : MonoBehaviour {
	Board board;
	// Use this for initialization
	void Start () {
		board = new Board("level");
		Camera.main.transform.position = new Vector3(10,10,-10);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.I)){
			print("HI");
			board.runOneStep();
		}
	}
}
