using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour {
	public float startRotation = 0;
	public float finalRotation = 60f;

	private float rotation = 0;
	private bool shouldRotate = false;
	private float progress = 0;

	void Update() {
		if (shouldRotate) progress += Time.deltaTime;
		rotation = Mathf.Lerp(startRotation, finalRotation, progress);
		transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
	}

	public void RotateFlag() {
		this.shouldRotate = true;
	}
}
