using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour {
	private static float TIME=450;
	private static string text="Nothing";
	private static List<Subject> subjectList = new List<Subject> {
		new Subject("Fisica",
			new Teacher("Abajos")
		),
		new Subject("Algebra",
			new Teacher("Conjunto Ahhhhh")
		),
		new Subject("API",
			new Teacher("Quemasda")
		)
	};
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void setText(string input){
		text = input;
	}
	public string getText(){
		return text;
	}
}

class GameTime {
	private static int sInM = 60;
	private static int mInH = 60;
	private static int hInD = 24;
	private static int dInSs = 28;
	private static int ssInY = 4;

	int sec { get; }
	int min { get; }
	int hour { get; }
	int day { get; }
	int season { get; }
	int year { get; }
	float mult { get; set; }

	public GameTime (int day, int season, int year, float mult)
	{
		sec = 0;
		min = 0;
		hour = 0;
		this.day = day;
		this.season = season;
		this.year = year;
		this.mult = mult;
	}

	public GameTime (int day, int season, int year)
	{
		GameTime (day, season, year, 60.0);
	}

	public GameTime()
	{
		GameTime (1, 1, 2015);
	}

	public void addSeconds(int seconds) {
		sec += seconds * mult;
		if (sec >= sInM)
		{
			min += (int) sec / sInM;
			sec = sec % sInM;

			if (min >= mInH)
			{
				hour += (int) min / mInH;
				min = min % mInH;

				if (hour >= hInD)
				{
					day += (int) hour / hInD;
					hour = hour % hInD;

					if (day >= dInSs + 1) {
						day--;
						season += (int) day / dInSs;
						day = day % dInSs;
						day++;

						if (season >= ssInY + 1) {
							season--;
							year += (int) season / ssInY;
							season = season % ssInY;
							season++;
					}
				}
			}
		}
	}
}

class Teacher {
	private static int lastId = 0;
	int id { get; }
	string name { get; set; }
	//void otherThings;

	public Teacher(string name) {
		this.name = name;
		this.id = lastId;
		lastId++;
	}
}

class Subject {
	private static int lastId = 0;
	int id { get; }
	string name { get; set; }
	//void minigame;
	Teacher teacher { get; set; }

	public Subject(string name, Teacher teacher) {
		this.name = name;
		this.teacher = teacher;
		this.id = lastId;
		lastId++;
	}
}
