using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Image speedImage;
	public Text speedDisplay;
	public Text positionDisplay;
	public ProgressBar distanceProgress;
	public Text halfGoalText;
	public Text goalText;
	public FlagScript halfGoalFlag;
	public FlagScript goalFlag;
	public Sprite[] speedIcons;
	public float[] speedThresholds;
	
	public void UpdateUI(GPSTracker gps, float goalDistance) {
		speedDisplay.text = gps.GetCurrentSpeedFormatted();

		double currentBaseSpeed = gps.CalculateCurrentSpeedWithoutUnits();
		int speedIndex = 0;
		foreach (float threshold in speedThresholds) {
			if (currentBaseSpeed >= threshold) speedIndex++;
		}

		speedImage.sprite = speedIcons[Mathf.Min(speedIndex, speedIcons.Length - 1)];

		LocationInfo? location = gps.GetPreviousLocationData();
		if (location.HasValue) {
			LocationInfo locationObj = location.Value;
			positionDisplay.text = $"Latitude: {locationObj.latitude.ToString("f3")}  Longitude: {locationObj.longitude.ToString("f3")}";
		}

		double distance = gps.GetTotalDistance();
		float progress = Mathf.Clamp01((float)distance / goalDistance);
		distanceProgress.UpdateProgress(progress);
		if (progress >= 0.5f) halfGoalFlag.RotateFlag();
		if (progress >= 1f) goalFlag.RotateFlag();

		GPSUnit distanceUnit = gps.GetDistanceUnit();
		goalText.text = distanceUnit.Format(goalDistance);
		halfGoalText.text = distanceUnit.Format(goalDistance/2);

	}

}
