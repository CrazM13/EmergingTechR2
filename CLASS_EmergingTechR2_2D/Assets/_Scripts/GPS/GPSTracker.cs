using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSTracker : MonoBehaviour {

	private float updateDistance = 10f;

	private double totalDistance = 0f;
	private double deltaDistance = 0f;
	private double totalTime = 0f;
	private double deltaTime = 0f;

	private GPSUnit distanceUnit = GPSUnit.METER;
	private GPSUnit timeUnit = GPSUnit.SECOND;

	private bool changeFlag = true;

	private LocationInfo? prevState = null;

	public float UpdateDistance {
		get { return updateDistance; }
		set {

			Input.location.Stop();

			updateDistance = value;

			Input.location.Start(updateDistance);

		}
	}

	public double CalculateAverageSpeed() {
		return totalTime != 0 ? totalDistance / totalTime : 0;
	}

	public double CalculateCurrentSpeed() {
		return deltaTime != 0 ? deltaDistance / deltaTime : 0;
	}

	public double GetTotalTime() {
		return timeUnit.ConvertFromBase(totalTime);
	}

	public double GetTotalDistance() {
		return distanceUnit.ConvertFromBase(totalDistance);
	}

	public void ResetGPSTracking() {
		totalDistance = 0;
		totalTime = 0;

		prevState = null;
		changeFlag = true;
	}

	public void SetUnits(GPSUnit distance, GPSUnit time) {
		this.distanceUnit = distance;
		this.timeUnit = time;
	}

	public bool ShouldUpdateValues() {
		return this.changeFlag;
	}

	public void SetUpdateValuesFlag(bool flg = true) {
		this.changeFlag = flg;
	}

	private void Start() {
		UpdateDistance = 10f;
	}

	private void Update() {
		if (Input.location.status == LocationServiceStatus.Running) {
			LocationInfo currentLocationDetails = Input.location.lastData;

			if (prevState.HasValue) {

				LocationInfo prevStateObj = prevState.Value;

				this.deltaDistance = CalculateDistance(currentLocationDetails.longitude, currentLocationDetails.latitude, prevStateObj.longitude, prevStateObj.latitude);
				this.deltaTime = (float)(currentLocationDetails.timestamp - prevStateObj.timestamp);

				this.totalDistance += this.deltaDistance;
				this.totalTime += this.deltaTime;

			}

			if (this.deltaDistance > 0) changeFlag = true;

			prevState = currentLocationDetails;

		}
	}

	public LocationInfo? GetPreviousLocationData() {
		return prevState;
	}

	private double CalculateDistance(double long1, double lat1, double long2, double lat2) {

		long1 = Mathf.Deg2Rad * long1;
		lat1 = Mathf.Deg2Rad * lat1;
		long2 = Mathf.Deg2Rad * long2;
		lat2 = Mathf.Deg2Rad * lat2;

		double deltaLong = long2 - long1;
		double deltaLat = lat2 - lat1;

		double a = Math.Pow(Math.Sin(deltaLat / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(deltaLong / 2), 2);
		double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

		return (float)6371000 * c;
	}

}
