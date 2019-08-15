using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public float goalDistance = 1f;
	public float goalDisplayDistance = 1f;


	// TMP
	public GPSTracker gps;
	public Text display;
	// END TMP

	void Start() {

		gps.SetUnits(GPSUnit.MILE, GPSUnit.HOUR);
		gps.UpdateDistance = 5f;

	}

	void Update() {
		// TMP
		if (gps.ShouldUpdateValues()) {
			LocationInfo? info = gps.GetPreviousLocationData();
			if (info.HasValue) {
				LocationInfo infoObj = info.Value;
				display.text = $"Latitude: {infoObj.latitude}\nLongitude: {infoObj.longitude}\nDistance: {gps.GetTotalDistanceFormatted()}\nSpeed: {gps.GetCurrentSpeedFormatted()}";
				gps.SetUpdateValuesFlag(false);
			} else {
				display.text = Input.location.status.ToString();
			}
		}
		// END TMP
	}
}
