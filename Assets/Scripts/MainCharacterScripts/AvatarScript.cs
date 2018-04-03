using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MORPH3D;

public class AvatarScript : MonoBehaviour
{
    private int count;
    private int numObjects = 1  ;
    private M3DCharacterManager m_CharacterManager;

    public Text countText;
    public Text winText;

    // Use this for initialization
    void Start()
    {
        count = 0;
        winText.text = "";
        countText.text = "Count: " + count.ToString();
        m_CharacterManager = GetComponent<M3DCharacterManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        m_CharacterManager = GetComponent<M3DCharacterManager>();
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            m_CharacterManager.SetBlendshapeValue("FBMHeavy", count * (100.0f/12));
            countText.text = "Count: " + count.ToString();

            if (count >= numObjects)
            {
                winText.text = "You Win";
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
