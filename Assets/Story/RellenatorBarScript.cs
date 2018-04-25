using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RellenatorBarScript : MonoBehaviour {
	public MainCharacter mainCharacterScript;
	public Image barMadness;
	public Text textMadness;
	public Image barInnerPeace;
	public Text textInnerPeace;
	public Image barSociability;
	public Text textSociability;
	private int maximum_width = 500;

	private int last_inner_peace;
	private int last_sociability;
	private int last_madness;
	private RectTransform trans;
	public Transform barPositionMadness;
	public Transform textPositionMadness;
	public Transform barPositionInnerPeace;
	public Transform textPositionInnerPeace;
	public Transform barPositionSociability;
	public Transform textPositionSociability;

	// Use this for initialization
	void Start () {
		float new_x;
		trans = barMadness.GetComponent<RectTransform>();
		//float new_x = barPositionMadness.position.x - (float)0.12*mainCharacterScript.getMadness();
		//barPositionMadness.position = new Vector3(new_x,barPositionMadness.position.y,barPositionMadness.position.z);
		new_x = textPositionMadness.position.x - (float)0.12*mainCharacterScript.getMadness();
		textPositionMadness.position = new Vector3(new_x,textPositionMadness.position.y,textPositionMadness.position.z);
		trans.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, mainCharacterScript.getMadness () * 5);
		textMadness.text = mainCharacterScript.getMadness ().ToString();

		trans = barInnerPeace.GetComponent<RectTransform>();
		//new_x = barPositionInnerPeace.position.x - (float)0.12*mainCharacterScript.getInnerPeace();
		//barPositionInnerPeace.position = new Vector3(new_x,barPositionInnerPeace.position.y,barPositionInnerPeace.position.z);
		new_x = textPositionInnerPeace.position.x - (float)0.12*mainCharacterScript.getInnerPeace();
		textPositionInnerPeace.position = new Vector3(new_x,textPositionInnerPeace.position.y,textPositionInnerPeace.position.z);
		trans.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, mainCharacterScript.getInnerPeace () * 5);
		textInnerPeace.text = mainCharacterScript.getInnerPeace ().ToString();

		trans = barSociability.GetComponent<RectTransform>();
		//new_x = barPositionSociability.position.x - (float)0.12*mainCharacterScript.getSociability();
		//barPositionSociability.position = new Vector3(new_x,barPositionSociability.position.y,barPositionSociability.position.z);
		new_x = textPositionInnerPeace.position.x - (float)0.12*mainCharacterScript.getSociability();
		textPositionSociability.position = new Vector3(new_x,textPositionSociability.position.y,textPositionSociability.position.z);
		trans.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, mainCharacterScript.getSociability () * 5);
		textSociability.text = mainCharacterScript.getSociability ().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		float new_x;
		if (mainCharacterScript.getMadness () != last_madness) {
			//float new_x = barPositionMadness.position.x - (float)0.12*mainCharacterScript.getMadness();
			//barPositionMadness.position = new Vector3(new_x,barPositionMadness.position.y,barPositionMadness.position.z);
			new_x = textPositionMadness.position.x - (float)0.12*mainCharacterScript.getMadness();
			textPositionMadness.position = new Vector3(new_x,textPositionMadness.position.y,textPositionMadness.position.z);	
			trans.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, mainCharacterScript.getMadness () * 5);
			last_madness = mainCharacterScript.getMadness ();
			textMadness.text = last_madness.ToString();
		}

		if (mainCharacterScript.getInnerPeace () != last_inner_peace) {
			//float new_x = barPositionInnerPeace.position.x - (float)0.12*mainCharacterScript.getInnerPeace();
			//barPositionInnerPeace.position = new Vector3(new_x,barPositionInnerPeace.position.y,barPositionInnerPeace.position.z);
			new_x = textPositionInnerPeace.position.x - (float)0.12*mainCharacterScript.getInnerPeace();
			textPositionInnerPeace.position = new Vector3(new_x,textPositionInnerPeace.position.y,textPositionInnerPeace.position.z);
			trans.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, mainCharacterScript.getInnerPeace () * 5);
			textInnerPeace.text = last_inner_peace.ToString();
		}

		if (mainCharacterScript.getSociability () != last_sociability) {
			//float new_x = barPositionSociability.position.x - (float)0.12*mainCharacterScript.getSociability();
			//barPositionSociability.position = new Vector3(new_x,barPositionSociability.position.y,barPositionSociability.position.z);
			new_x = textPositionInnerPeace.position.x - (float)0.12*mainCharacterScript.getSociability();
			textPositionSociability.position = new Vector3(new_x,textPositionSociability.position.y,textPositionSociability.position.z);
			trans.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, mainCharacterScript.getSociability () * 5);
			textSociability.text = last_sociability.ToString();
		}

	}
}
