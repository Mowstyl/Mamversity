using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GlobalVariables {
	private static GameTime gameTime = new GameTime();
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

	public static GameTime getGameTime() {
		return gameTime;
	}

	public static GameTimeStruct getTime() {
		GameTimeStruct gts = new GameTimeStruct ();
		gts.sec = gameTime.sec;
		gts.min = gameTime.min;
		gts.hour = gameTime.hour;
		gts.day = gameTime.day;
		gts.season = gameTime.season;
		gts.year = gameTime.year;
		return gts;
	}

	public static string getText() {
		return text;
	}

	public static void setText(string s) {
		text = s;
	}
}

public struct GameTimeStruct {
	public float sec;
	public int min, hour, day, season, year;
}

public enum Seasons {
	FALL = 1,
	WINTER = 2,
	SPRING = 3,
	SUMMER = 4
}

public class GameTime {
	private static int sInM = 60;
	private static int mInH = 60;
	private static int hInD = 24;
	private static int dInSs = 28;
	private static int ssInY = 4;

	public float sec { get; private set; }
	public int min { get; private set; }
	public int hour { get; private set; }
	public int day { get; private set; }
	public int season { get; private set; }
	public int year { get; private set; }
	public float mult { get;  private set; }

	public GameTime (float sec, int min, int hour, int day, int season, int year, float mult)
	{
		this.sec = sec;
		this.min = min;
		this.hour = hour;
		this.day = day;
		this.season = season;
		this.year = year;
		this.mult = mult;
	}
		
	public GameTime (int day, int season, int year, float mult) : this (0, 0, 8, day, season, year, mult) { }

	public GameTime (int day, int season, int year) : this (day, season, year, (float) 60) { }

	public GameTime() : this (1, 1, 2015) { }

	public void addSeconds(float seconds, float speed) {
		sec += seconds * mult * speed;
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

	public void addSeconds(float seconds) {
		addSeconds (seconds, 1);
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
