using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TextScript : MonoBehaviour {

	public Text text;
	public GlobalVariables global_variables;

	// Use this for initialization
	void Start () {
		text.text = global_variables.getText ();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
