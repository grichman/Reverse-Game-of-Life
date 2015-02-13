using UnityEngine;
using System.Collections;

public class InputTile : MonoBehaviour {
	private const float outlineWidth = 0.04f;
	GameObject outlineObject;
	GameObject modelObject;
	public bool isOn;
	// Use this for initialization
	void Start () {
		modelObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
		modelObject.renderer.material.color = Color.white;
		modelObject.transform.localScale *= (1 - outlineWidth);
		modelObject.transform.position = this.transform.position;
		modelObject.transform.parent = this.transform;
		modelObject.layer = LayerMask.NameToLayer("Ignore Raycast");

		outlineObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
		outlineObject.renderer.material.color = Color.black;
		outlineObject.transform.position = this.transform.position;
		outlineObject.transform.parent = this.transform;
		outlineObject.layer = LayerMask.NameToLayer("Ignore Raycast");

		this.gameObject.AddComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown() {
		print("ASD");
		if (modelObject.renderer.material.color == Color.white){
			modelObject.renderer.material.color = Color.red;
			isOn = true;
		}
		else if (modelObject.renderer.material.color == Color.red){
			modelObject.renderer.material.color = Color.white;
			isOn = false;
		}

	}


}
