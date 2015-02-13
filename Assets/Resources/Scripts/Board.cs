using UnityEngine;
using System.Collections;

public class Board {
	Tile[,] board;
	/// <summary>
	/// Initializes a blank board of the specified dimensions
	/// </summary>
	/// <param name="dimensions">The dimensions to make the board</param>
	public Board (int width, int height) {
		fillBoard( new bool[width, height] );
	}

	public Board(bool[,] initialBoard){
		fillBoard(initialBoard);
	}

	public Board(string fname){
		TextAsset config = Resources.Load<TextAsset>("Boards/"+fname);
		string[] lines = config.text.Trim().Split(   new char[]{'\n'}   );
		bool[,] board = new bool[lines.Length, (lines[0].Length + 1)/2];
		for(int j = 0; j < lines.Length; j++){
			string[] cells = lines[j].Split(new char[] {','});
			for (int i = 0; i < cells.Length; i++){
				board[i,lines.Length - j - 1] = cells[i] == "1";
			}
		}
		fillBoard(board);
	}

	private void fillBoard(bool[,] initialBoard){
		board = new Tile[initialBoard.GetLength(0), initialBoard.GetLength(1)];
		for(int i = 0; i < initialBoard.GetLength(0); i++){
			for(int j = 0; j < initialBoard.GetLength(1); j++){
				GameObject obj = new GameObject();
				Tile tile = obj.AddComponent<Tile>();
				tile.isOn = initialBoard[i,j];
				obj.transform.position = tile.transform.position = new Vector2(i, j);
				board[i,j] = tile;
			}
		}

	}
	/// <summary>
	/// Runs one step of the life algorithm
	/// </summary>
	public void runOneStep(){
		for (int i = 0; i < board.GetLength(0); i++){
			for (int j = 0; j < board.GetLength(1); j++){
				int neighbors = countNeighbors(i,j);
				//if it has fewer than two neighbors it dies of loneliness
				if (neighbors < 2) board[i,j].isOn = false;
				//if it has 3 neighbors it becomes alive
				else if (neighbors == 3) board[i,j].isOn = true;
				//if it has 4 or more neighbors it dies of resource shortage
				else if (neighbors >= 4) board[i,j].isOn = false;
			}
		}
	}

	/// <summary>
	/// Counts a cell's neighbors
	/// </summary>
	/// <returns>The neighbors.</returns>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	private int countNeighbors(int x, int y){
		int neighbors = 0;
		for(int i = -1; i <= 1; i++){
			for(int j = -1; j <= 1; j++){
				int xPos = (x + i + board.GetLength(0))%board.GetLength(0);
				int yPos = (y + j + board.GetLength(1))%board.GetLength(1);
				if (i != 0 || j != 0) neighbors += board[xPos,yPos].isOn ? 1 : 0;
			}
		}
		return neighbors;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
