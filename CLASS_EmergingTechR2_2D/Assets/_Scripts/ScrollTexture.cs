using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ScrollTexture : MonoBehaviour {

	public float speed = 1f;
	private RawImage ri;

	void Start() {
		ri = GetComponent<RawImage>();
	}

	void Update() {

		float x = (ri.uvRect.x + speed * Time.deltaTime) % 1;

		ri.uvRect = new Rect(new Vector2(x, 0), ri.uvRect.size);
	}
}
