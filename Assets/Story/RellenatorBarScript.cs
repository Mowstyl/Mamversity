using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RellenatorBarScript : MonoBehaviour {
	public MainCharacter mainCharacterScript;
	public Canvas HUD;
	private int maximum_width = 500;

	private int last_inner_peace;
	private int last_sociability;
	private int last_madness;

	// Use this for initialization
	void Start () {
		Image bar;
		bar = HUD.GetComponent<Image>();
		RectTransform trans = bar.GetComponent<RectTransform>();
		trans.anchorMin =(new Vector2(-100, 150));
		trans.anchorMax =(new Vector2 (-100+(maximum_width/(mainCharacterScript.getMadness()/100)),180));		
	}
	
	// Update is called once per frame
	void Update () {
		Image bar;
		if (mainCharacterScript.getMadness () != last_madness) {
			bar = HUD.GetComponent<Image>();
			RectTransform trans = bar.GetComponent<RectTransform>();
			trans.anchorMin= (new Vector2 (-100, 150));
			trans.anchorMax= (new Vector2 (-100+(maximum_width/(mainCharacterScript.getMadness()/100)),180));
		}
		
	}
}
