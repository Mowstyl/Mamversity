using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RellenatorBarScript : MonoBehaviour {
	public MainCharacter mainCharacterScript;
	public RectTransform barPosition;
	public Text text;

	public Variable variable;

	private int last_value;
	private float barWidth;

	private Func<int> getValue;

	// Use this for initialization
	void Start () {
		switch (variable) {
		case Variable.INNER_PEACE:
			getValue = mainCharacterScript.getInnerPeace;
			break;
		case Variable.SOCIABILITY:
			getValue = mainCharacterScript.getSociability;
			break;
		case Variable.MADNESS:
			getValue = mainCharacterScript.getMadness;
			break;
		}
		barWidth = barPosition.rect.width;

		last_value = -1;
	}
	
	// Update is called once per frame
	void Update () {
		int value = getValue ();

		if (value != last_value) {
			barPosition.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, barWidth * ((float) value / 100));

			last_value = value;
			//text.text = value.ToString() + "/" + "100";
			text.text = value.ToString();
		}

	}
}

public enum Variable {
	INNER_PEACE, SOCIABILITY, MADNESS
}
