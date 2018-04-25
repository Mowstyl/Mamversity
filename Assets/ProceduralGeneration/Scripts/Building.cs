using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    public GameObject Ledge; 
	public List<Vector3> centers=new List<Vector3>();


	void Start () {
		gen();
	}

    void gen()
    {
        int count = this.transform.childCount;
		//Vector3 temp = centers;


        for (int i = 0; i < count; ++i)
        {
            Vector3 scale = this.transform.GetChild(i).transform.localScale;
            this.transform.GetChild(i).transform.localScale = new Vector3(scale.x + Random.Range(1.25f, 2.0f),
				Random.Range(1.0f, 15.0f), Random.Range(1.25f, 2.0f) + scale.z);
            GameObject led = Instantiate(Ledge);
            led.transform.parent = this.transform.GetChild(i).transform;
            led.transform.localRotation = this.transform.GetChild(i).transform.localRotation;
            led.transform.localPosition = new Vector3(0, 1, 0);
            led.transform.localScale = new Vector3(1, 1.5f/transform.GetChild(i).transform.localScale.y, 1);
			//led.name = "building_"+i;
        }
		//this.transform.position = new Vector3(0.0f+Random.Range(1,254), 1.5f+Random.Range(1,254), 0.0f+Random.Range(1,254));
    }
}