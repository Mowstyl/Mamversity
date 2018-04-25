using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour {
	private string playername;
	private string surname;
	private int sociability;
	private int inner_peace;
	private int drunk_relationship;
	private int lover_relationship;
	private int nerd_relationship;
	private int madness = 15;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string getName(){
		return playername;
	}
	public void setName(string new_name){
		playername = new_name;
	}
	public string getSurname(){
		return surname;
	}
	public void setSurname(string new_surname){
		surname = new_surname;
	}
	public int getSociability(){
		return sociability;
	}
	public void increaseSociability(int increasing){
		sociability +=increasing;
	}
	public int getInnerPeace(){
		return inner_peace;
	}
	public void increaseInnerPeace(int increasing){
		inner_peace +=increasing;
	}
	public int getDrunkRelationship(){
		return drunk_relationship;
	}
	public void increaseDrunkRelationship(int increasing){
		drunk_relationship+=increasing;
	}
	public int getLoverRelationship(){
		return lover_relationship;
	}
	public void increaseLoverRelationship(int increasing){
		lover_relationship+=increasing;
	}
	public int getNerdRelationship(){
		return nerd_relationship;
	}
	public void increaseNerdRelationship(int increasing){
		nerd_relationship +=increasing;
	}
	public int getMadness(){
		return madness;
	}
	public void increaseMadness(int increasing){
		madness+=increasing;
	}
}
