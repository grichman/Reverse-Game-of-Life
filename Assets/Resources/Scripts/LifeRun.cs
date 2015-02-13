using UnityEngine;
using System.Collections;

public class LifeRun : MonoBehaviour {
	private const float stepTime = 0.1f;
	Board board;
	// Use this for initialization
	void Start () {
		board = new Board("level");
		Camera.main.transform.position = new Vector3(10,10,-10);
	}

	bool isRunning = false;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.I)){
			print("HI");
			board.runOneStep();
		}
		if (Input.GetKeyUp(KeyCode.Return)){
			if (!isRunning){
				StartCoroutine("runLife");
			}else{
				StopCoroutine("runLife");
			}
		}
	}

	IEnumerator runLife(float stepTime = LifeRun.stepTime){
		while(true){
			yield return new WaitForSeconds(stepTime);
			board.runOneStep();
		}
	}
}
