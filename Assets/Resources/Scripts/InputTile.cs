using UnityEngine;
using System.Collections;

public class InputTile : MonoBehaviour {
	private const float outlineWidth = 0.04f;
	GameObject outlineObject;
	GameObject modelObject;
	// Use this for initialization
	void Start () {
		modelObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
		modelObject.renderer.material.color = Color.white;
		modelObject.transform.localScale *= (1 - outlineWidth);
		modelObject.transform.position = this.transform.position;
		modelObject.transform.parent = this.transform;

		outlineObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
		outlineObject.renderer.material.color = Color.black;
		outlineObject.transform.position = this.transform.position;
		outlineObject.transform.parent = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
