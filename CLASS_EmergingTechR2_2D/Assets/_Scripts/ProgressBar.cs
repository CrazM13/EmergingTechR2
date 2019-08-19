using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

	public Image background;
	public Image foreground;

	private float progress = 0f;
	private float displayProgress = 0f;

	private Vector2 fullSize;

	private void Start() {
		fullSize = foreground.rectTransform.sizeDelta;
		foreground.rectTransform.sizeDelta = new Vector2(fullSize.x * displayProgress, fullSize.y);
	}

	void Update() {
		if (displayProgress < progress) {
			displayProgress = Mathf.Lerp(displayProgress, progress, Time.deltaTime);

			foreground.rectTransform.sizeDelta = new Vector2(fullSize.x * displayProgress, fullSize.y);
		}
	}

	public void UpdateProgress(float progress) {
		this.progress = progress;
	}
}
