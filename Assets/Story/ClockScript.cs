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
	public GlobalVariables globalVariables;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float time = Time.time;
		if(last_update + 1 <= time){
			int sec = globalVariables.getTime().sec;
			int min = globalVariables.getTime().min;
			int hour = globalVariables.getTime().hour;
			int day = globalVariables.getTime().day;
			int season = globalVariables.getTime().season;
			int year = globalVariables.getTime().year;
			String min_string;
			String hour_string;
			if (min < 10) {
				min_string = '0' + min.ToString();
			} else
				min_string = min.ToString();
			if (hour < 10) {
				hour_string = '0' + hour.ToString();
			} else
				hour_string = hour.ToString();
			text.text = hour_string+ " : " + min_string;
			last_update = time;
		}
	}
	void FixedUpdate(){
	}
}
