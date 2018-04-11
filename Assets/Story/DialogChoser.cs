using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogChoser : MonoBehaviour {

	public Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			text.text= "Don't worry.";
		}if(Input.GetKeyDown(KeyCode.Alpha2)){
			text.text="Yes, but not as much as you.";
		}
	}
}
