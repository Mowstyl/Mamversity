using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MCSController : MonoBehaviour {
    private int count;
    private int numObjects = 10;

    public Text countText;
    public Text winText;

	// Use this for initialization
	void Start () {
        count = 0;
        winText.text = "";
        countText.text = "Count: " + count.ToString();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            countText.text = "Count: " + count.ToString();

            if (count >= numObjects)
            {
                winText.text = "You Win";
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
