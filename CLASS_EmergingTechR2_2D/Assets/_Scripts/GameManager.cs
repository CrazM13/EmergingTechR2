using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public float goalDistance = 1f;

	public GPSTracker gps;
	public UIManager ui;

	void Start() {

		gps.SetUnits(GPSUnit.MILE, GPSUnit.HOUR);
		gps.UpdateDistance = 5f;

		ui.UpdateUI(gps, goalDistance);

	}

	void Update() {
		if (gps.ShouldUpdateValues()) {
			gps.SetUpdateValuesFlag(false);
			ui.UpdateUI(gps, goalDistance);
		}
	}
}
