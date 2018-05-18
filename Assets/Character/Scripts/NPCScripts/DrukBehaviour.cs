using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrukBehaviour : MonoBehaviour {

    private Animator anim;
    private float waking;
    private float turning;

    //deathTime is the time interval that is going to call "Deth"
    public float deathTime = 3f;

    //Variables to the movement
    private bool flag1, flag2;
    public bool isTalking;
    public int turnspeed;
    // Use this for initialization
    void Start()
    {
        
        anim = GetComponent<Animator>();
        waking = 0.0f;
        turning = 0.0f;

        flag1 = true;
        flag2 = true;
        isTalking = false;

        //InvokeRepeating("Death", deathTime, deathTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTalking)
        {
            Movement();
        }
        else
        {
            anim.SetFloat("waking", 0.0f);
            transform.Rotate(new Vector3(0.0f, 0.0f));
        }
    }

    private void Movement()
    {
        Vector3 position = new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 0, UnityEngine.Random.Range(-10.0f, 10.0f));

        int rnd = UnityEngine.Random.Range(0, 100);
        int rnd2 = UnityEngine.Random.Range(0, 100);


        if (flag1)
        {
            waking = Input.GetAxis("Vertical");
            anim.SetFloat("waking", 1.0f);
        }
        else
        {
            waking = Input.GetAxis("Vertical");
            anim.SetFloat("waking", 0.0f);
        }

        if (rnd > 95)
        {
            flag1 = !flag1;
        }
        if (rnd2 > 95)
        {
            flag2 = !flag2;
        }

        if (flag2)
        {
            turning = 1.0f;
            transform.Rotate(new Vector3(0.0f, turnspeed * turning * Time.deltaTime));
        }
        else
        {
            turning = -1.0f;
            transform.Rotate(new Vector3(0.0f, turnspeed * turning * Time.deltaTime));
        }

    }

    void Death()
    {
        int rnd = UnityEngine.Random.Range(0, 100);

        if (rnd > 60)
        {
            Destroy(gameObject, 2f);
        }
    }

    public void IsTalking()
    {
        isTalking = true; }
    public void IsNotTalking()
    {
        isTalking = false; }
}
