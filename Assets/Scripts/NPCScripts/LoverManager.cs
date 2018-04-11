using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoverManager : MonoBehaviour
{

    public GameObject lover;

    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public int numLovers = 0;

  
   

    // Use this for initialization
    void Start()
    {

        InvokeRepeating("Spawn", spawnTime, spawnTime);
        InvokeRepeating("Talk", spawnTime, spawnTime);

        lover.GetComponent<TextMesh>().text = "Hola guapo";
        

    }

    // Update is called once per frame
    void Spawn()
    {
        if (numLovers <= 0) { return; }
        for (; numLovers > 0; numLovers--)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(lover, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
           
        }
    }

    void Talk()
    {
        GetComponent<TextMesh>().text = "Hola guapo";
    }
}
