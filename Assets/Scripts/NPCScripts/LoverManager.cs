using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoverManager : MonoBehaviour {

    public GameObject lover;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public int numLovers = 0;
	// Use this for initialization
	void Start () {
        
        InvokeRepeating("Spawn", spawnTime, spawnTime);

	}
	
	// Update is called once per frame
	void Spawn () {
        if (numLovers <= 0) { return; }
        for (; numLovers >= 0 ; numLovers --)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(lover, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
	}
}
