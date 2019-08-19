using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateImage : MonoBehaviour {

	public float speed;

	void Start() {

	}

	void Update() {
		transform.Rotate(Vector3.forward, speed * Time.deltaTime);
	}
}
