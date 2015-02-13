using UnityEngine;
using System.Collections;

public class InputTile : Tile {
	
	void OnMouseDown() {
		base.isOn = !base.isOn;
	}


}
