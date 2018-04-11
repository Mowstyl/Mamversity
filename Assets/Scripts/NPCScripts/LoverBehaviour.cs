using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoverBehaviour : MonoBehaviour {

    private Animator anim;
    private float waking;
    private float turning;
    private string[] phrases;

    private Vector3 offsetToDrunk;

    //deathTime is the time interval that is going to call "Deth"
    public float deathTime = 3f;

    //Variables to the movement
    private bool flag1, flag2;
    public int turnspeed;
    public GameObject drunk;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        waking = 0.0f;
        turning = 0.0f;

        flag1 = true;
        flag1 = true;

        phrases = new string[] { "Hi", "I love you baby", "Call me pls" };
        InvokeRepeating("Talk", deathTime, deathTime);

        offsetToDrunk = transform.position - drunk.transform.position;

    }

    // Update is called once per frame
    void Update()
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

   void Talk()
    {
        

        GameObject closest;
        float distance = Mathf.Infinity;
        var position = transform.position;
        GameObject[] npcs;
        npcs = GameObject.FindGameObjectsWithTag("Main Character");
        if (npcs.Length == 0){
            GetComponent<TextMesh>().text = "aqui no hay nadie";
        }
        // Find the closest one
        foreach (GameObject chara in npcs)
        {
            var diff = (chara.transform.position - position);
            var curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = chara;
                distance = curDistance;
            }
        }
        if (distance < 5)
        {
            //Debug.Log("The closest npc is" + closest.tag.ToString());
            //closest.SendMessage("dialogue");
            GetComponent<TextMesh>().text = "You are to close";
        }
        else { GetComponent<TextMesh>().text = "You are to far"; }

        //if  (GetComponent<TextMesh>().text != "")
        //{
        //    int rnd = UnityEngine.Random.Range(0, 3);
        //    switch (rnd)
        //    {
        //        case 0:
        //            GetComponent<TextMesh>().text = phrases[0];
        //            break;
        //        case 1:
        //            GetComponent<TextMesh>().text = phrases[1];
        //            break;
        //        case 2:
        //            GetComponent<TextMesh>().text = phrases[2];
        //            break;
        //    }
        //}
        //else
        //{
        //    GetComponent<TextMesh>().text = "";          
        //}
        
        
    }
}
