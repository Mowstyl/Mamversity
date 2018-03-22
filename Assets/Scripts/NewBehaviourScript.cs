using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    private Animator anim;
    private float waking;
    private float turning;

    private bool flag1, flag2;
    public int turnspeed;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        waking = 0.0f;
        turning = 0.0f;

        flag1 = true;
        flag1 = true;
    }
	
	// Update is called once per frame
	void Update () {

        
            waking = Input.GetAxis("Vertical");
            anim.SetFloat("waking", waking);
   
      
            turning = Input.GetAxis("Horizontal");
            transform.Rotate(new Vector3(0.0f, turnspeed * turning * Time.deltaTime));
      
       

    }

    
}
