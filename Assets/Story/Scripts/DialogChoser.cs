using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogChoser : MonoBehaviour {

	public Text text;
	private bool answered;
	public GameObject displayer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && answered) {
			displayer.SetActive (false);
		}
		if(Input.GetKeyDown(KeyCode.Alpha1) && !answered){
			text.text= "Don't worry.";
			answered = true;
		}if(Input.GetKeyDown(KeyCode.Alpha2) && !answered){
			text.text="Yes, but not as much as you.";
			answered = true;
		}
	}
}
