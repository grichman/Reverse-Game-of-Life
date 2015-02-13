using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	private const float outlineWidth = 0.04f;
	protected GameObject outlineObject;
	protected GameObject modelObject;
	public bool isOn;

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
		modelObject.renderer.material.color = isOn ? Color.red : Color.white;
	}
}
