using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class InputReader : MonoBehaviour {
	InputTile[,] tiles;
	// Use this for initialization
	void Start () {
		//initialize a board of 50 tiles
		tiles = new InputTile[5,5];
		for (int i = 0; i < tiles.GetLength(0); i++){
			for(int j = 0; j < tiles.GetLength(1); j++){
				GameObject obj = new GameObject();
				InputTile tile = obj.AddComponent<InputTile>();
				obj.transform.position = tile.transform.position = new Vector2(i, j);
				tiles[i,j] = tile;
			}
		}

		Camera.main.transform.position = new Vector3(10,10,-10);
	}

	/// <summary>
	/// Finds which tiles are on
	/// </summary>
	/// <returns>A 2D boolean array of on tiles</returns>
	bool[,] findOnTiles(){
		bool[,] onTiles = new bool[tiles.GetLength(0), tiles.GetLength(1)];
		for(int i = 0; i < tiles.GetLength(0); i++){
			for(int j = 0; j < tiles.GetLength(1); j++){
				if (tiles[i,j].isOn) onTiles[i,j] = true;
			}
		}
		return onTiles;
	}
	
	/// <summary>
	/// Use WASD and (z-backward, x-forward) to contorl the camera
	/// </summary>
	void Update () {
		Dictionary<KeyCode, Vector3> dirs = new Dictionary<KeyCode, Vector3>();
		dirs.Add(KeyCode.W, Vector3.up);
		dirs.Add(KeyCode.A, Vector3.left);
		dirs.Add(KeyCode.S, Vector3.down);
		dirs.Add(KeyCode.D, Vector3.right);
		dirs.Add(KeyCode.X, Vector3.forward);
		dirs.Add(KeyCode.Z, Vector3.back);

		Dictionary<KeyCode, Vector3>.Enumerator itr = dirs.GetEnumerator();
		while(itr.MoveNext()){
			if (Input.GetKeyDown(itr.Current.Key)){
				Camera.main.transform.position += itr.Current.Value;
			}
		}
		
		if (Input.GetKeyUp (KeyCode.Return)){
			StreamWriter levelStream = File.CreateText("Assets/Resources/Boards/level.txt");
			for (int j = tiles.GetLength(1) - 1; j >= 0; j--){
				StringBuilder rowString = new StringBuilder();
				for (int i = 0; i < tiles.GetLength(0); i++){
					string tileString = tiles[i,j].isOn ? "1," : "0,";
					rowString.Append(tileString);
				}
				rowString.Remove(rowString.Length - 1, 1);
				print(rowString.ToString());
				levelStream.WriteLine(rowString.ToString());
			}
			levelStream.Close();

		}
	}

	void OnGUI(){
		GUI.Label(new Rect(50,50,50,50), "HELLO");
	}

}
