using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
	public void ChangeToScene (){
		SceneManager.LoadScene("The other clock",LoadSceneMode.Single);
	}
}
