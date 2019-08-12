using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSUnit {

	public static readonly GPSUnit CENTIMETER = new GPSUnit("Cm", 0.01f);
	public static readonly GPSUnit METER = new GPSUnit("M", 1f);
	public static readonly GPSUnit KILOMETER = new GPSUnit("Km", 1000f);

	public static readonly GPSUnit SECOND = new GPSUnit("s", 1f);
	public static readonly GPSUnit MINUTE = new GPSUnit("m", 1f/60f);
	public static readonly GPSUnit HOUR = new GPSUnit("h", 1f/3600f);

	private double multiplierFromBase = 1f;
	private string name = "";

	public GPSUnit(string name, double multiplierFromBase) {
		this.name = name;
		this.multiplierFromBase = multiplierFromBase;
	}

	public double ConvertFromBase(double value) {
		return value * this.multiplierFromBase;
	}

	public double ConvertFromUnit(double value, GPSUnit unit) {
		return this.ConvertFromBase(unit.ConvertToBase(value));
	}

	public double ConvertToUnit(double value, GPSUnit unit) {
		return unit.ConvertFromBase(this.ConvertToBase(value));
	}

	public double ConvertToBase(double value) {
		return value / this.multiplierFromBase;
	}

}
