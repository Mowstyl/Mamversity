using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkManager : MonoBehaviour {

    public GameObject drunk;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Spawn () {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(drunk, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
