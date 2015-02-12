using UnityEngine;
using System.Collections;

public class InputReader : MonoBehaviour {
	GameObject[,] tiles;
	// Use this for initialization
	void Start () {
		//tiles = new GameObject[100,100];
		GameObject obj = new GameObject();
		InputTile tile = obj.AddComponent<InputTile>();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
