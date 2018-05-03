using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct DialogNode{
	public DialogNode[] dialog_nodes;
	public string[] dialog_options;
	public string question;

	public DialogNode(DialogNode[] dialog_nodes, string[] dialog_options, string question){
		this.dialog_nodes = dialog_nodes;
		this.dialog_options = dialog_options;
		this.question = question;
	}
	public DialogNode(DialogNode[] dialog_nodes, string question){
		this.dialog_nodes = dialog_nodes;
		this.dialog_options = new string[]{"Continue"};
		this.question = question;
	}
}

public class DialogChoser : MonoBehaviour {

	public Text text;
	public GameObject displayer;
	private DialogNode currentNode;

	private DialogNode opt1=new DialogNode(null ,"Don't worry");
	private DialogNode opt2=new DialogNode(null, "Yes, but not as much as you");
	private DialogNode[] main_node_nodes = { opt1, opt2 };
	private string[] main_node_opt = {"Sorry, my fault","Are you an idiot?"}
	private DialogNode dialog=new DialogNode(aux,main_node_opt,"Hey! Look where are you going!");

	// Use this for initialization
	void Start () {
		currentNode = dialog;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = currentNode.question;
		int i = 0;
		foreach (string option in currentNode.dialog_options) {
			i++;
			text.text = text.text + '\n' + i + ") " + option;
		}
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			currentNode = currentNode.dialog_nodes [0];
		}if(Input.GetKeyDown(KeyCode.Alpha2)){
			currentNode = currentNode.dialog_nodes [1];
		}if(Input.GetKeyDown(KeyCode.Alpha3)){
			currentNode = currentNode.dialog_nodes [2];
		}if(Input.GetKeyDown(KeyCode.Alpha4)){
			currentNode = currentNode.dialog_nodes [3];
		}if(Input.GetKeyDown(KeyCode.Alpha5)){
			currentNode = currentNode.dialog_nodes [4];
		}if(Input.GetKeyDown(KeyCode.Alpha6)){
			currentNode = currentNode.dialog_nodes [5];
		}
	}
}




