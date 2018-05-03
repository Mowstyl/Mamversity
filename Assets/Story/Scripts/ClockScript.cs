using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

public class ClockScript : MonoBehaviour {

	private float starting_time;
	private float last_update;
	public Text text;

	// Use this for initialization
	void Start () {
		updateTime (text);
		last_update = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float time = Time.time;

		if(last_update + 1 <= time)
		{
			updateTime (text);
			last_update = time;
		}
	}

	public string getSeason(int season)
	{
		switch (season) {
		case (int) Seasons.WINTER:
			return "Winter";
			break;
		case (int) Seasons.SPRING:
			return "Spring";
			break;
		case (int) Seasons.SUMMER:
			return "Summer";
			break;
		default:
			return "Fall";
			break;
		}
	}

	public void updateTime(Text t) {
		float sec = GlobalVariables.getTime().sec;
		int min = GlobalVariables.getTime().min;
		int hour = GlobalVariables.getTime().hour;
		int day = GlobalVariables.getTime().day;
		int season = GlobalVariables.getTime().season;
		int year = GlobalVariables.getTime().year;

		String sec_string, min_string, hour_string, day_string, season_string, year_string;

		sec_string = sec.ToString ();
		min_string = min.ToString ();
		hour_string = hour.ToString ();
		day_string = day.ToString ();

		if (sec < 10) {
			sec_string = '0' + sec_string;
		}

		if (min < 10) {
			min_string = '0' + min_string;
		}

		if (hour < 10) {
			hour_string = '0' + hour_string;
		}

		if (day < 10) {
			day_string = '0' + day_string;
		}

		season_string = getSeason (season);

		year_string = year.ToString ();

		//t.text = year_string + ", " + season_string + " " + day_string + "\n" + hour_string+ " : " + min_string + " : " + sec_string;
		t.text = year_string + ", " + season_string + " " + day_string + "\n" + hour_string+ " : " + min_string;
	}
}
