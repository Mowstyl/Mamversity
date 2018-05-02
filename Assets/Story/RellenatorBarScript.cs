using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RellenatorBarScript : MonoBehaviour {
	public MainCharacter mainCharacterScript;
	public Text text;

	public RectTransform barPosition;
	public RectTransform textPosition;
	public Variable variable;

	private int last_value;
	private float textXOffset;
	private float barXOffset;

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

		last_value = -1;
	}
	
	// Update is called once per frame
	void Update () {
		int value = getValue ();

		if (value != last_value) {
			//float new_x = (barPosition.anchoredPosition.x + barPosition.sizeDelta.x / 2) - textPosition.sizeDelta.x / 2;
			//textPosition.position = new Vector3(textPosition.position.x - value, textPosition.position.y, textPosition.position.z);

			barPosition.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, value * 3);

			last_value = value;
			text.text = value.ToString() + "/" + "100";
		}

	}
}

public enum Variable {
	INNER_PEACE, SOCIABILITY, MADNESS
}
