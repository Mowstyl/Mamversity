using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsBuilding: MonoBehaviour {

	void OnCollisionEnter(Collision col) {
		if(col.gameObject.name == "NombreCaracter") {
			//Abrir escenario de minijuegos
		}
	}
}

