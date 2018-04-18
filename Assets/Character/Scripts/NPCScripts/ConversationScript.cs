using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationScript : MonoBehaviour {

    public GameObject one;
    public GameObject two;

    private TextMesh oneText;
    private TextMesh twoText;
    // Use this for initialization
    void Start (GameObject one, GameObject two) {
        oneText = one.GetComponent<TextMesh>();
        twoText = two.GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Conversation ()
    {
        int rnd = UnityEngine.Random.Range(0, 2);
        switch (rnd)
        {
            case 0:
                oneText.text = "You are beautiful";
                twoText.text = "You're not, sry :)";
                break;
            case 1:
                oneText.text = "Hellow";
                twoText.text = "Hi";
                break;
            case 2:
                oneText.text = "Bye";
                twoText.text = "I hope I will never see you again";
                break;
        }
    }
}
