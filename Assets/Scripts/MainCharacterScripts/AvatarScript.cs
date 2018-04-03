using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MORPH3D;

public class AvatarScript : MonoBehaviour
{
    private int count = 0;
    private int numObjects = 1  ;
    private M3DCharacterManager m_CharacterManager;


    // Use this for initialization
    void Start()
    {
       

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
           

        }
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
