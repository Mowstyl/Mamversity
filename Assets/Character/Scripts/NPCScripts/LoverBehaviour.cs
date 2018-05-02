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
    private bool flag1, flag2,isTalking,courrutine;
    public int turnspeed;
    public GameObject drunk;
    //public ConversationScript conversation;

   
    public GameObject two;

    private TextMesh oneText;
    private TextMesh twoText;

    // Use this for initialization
    void Start()
    {
        oneText = GetComponent<TextMesh>();
        //twoText = two.GetComponent<TextMesh>();
        anim = GetComponent<Animator>();
        waking = 0.0f;
        turning = 0.0f;

        flag1 = true;
        flag2 = true;
        isTalking = false;
        courrutine = false;

        phrases = new string[] { "Hi", "I love you baby", "Call me pls" };
        InvokeRepeating("Talk", deathTime, deathTime);

        offsetToDrunk = transform.position - drunk.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isTalking)
        {
            Movement();
        }
        else {
            anim.SetFloat("waking", 0.0f);
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

    void Talk()
    {
        if (!isTalking)
        {
            isTalking = true;
            GameObject closest = new GameObject();
            float distance = Mathf.Infinity;
            var position = transform.position;
            GameObject[] npcs;
            npcs = GameObject.FindGameObjectsWithTag("Drunk");
            if (npcs.Length == 0)
            {
                // GetComponent<ScriptableObject>(). = "aqui no hay nadie";
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
            two = closest;
            twoText = two.GetComponent<TextMesh>();
            DrukBehaviour scr = two.GetComponent<DrukBehaviour>();
            scr.isTalking = true;
            if (distance < 5)
            {
                if (twoText != null)
                {
                    int rnd = UnityEngine.Random.Range(0, 3);
                    switch (rnd)
                    {
                        case 0:
                            twoText.text = "You are beautiful";
                            while (!courrutine) {
                                StartCoroutine(WaitForConversation(3));
                            }
                            oneText.text = "You're not, sry :)";
                            while (!courrutine)
                            {
                                StartCoroutine(WaitForConversation(3));
                            }
                            twoText.text = "So sad";
                            break;
                        case 1:
                            twoText.text = "Hellow";
                            while (!courrutine)
                            {
                                StartCoroutine(WaitForConversation(3));
                            }
                            oneText.text = "Hi";
                            while (!courrutine)
                            {
                                StartCoroutine(WaitForConversation(3));
                            }
                            twoText.text = "See you later aligater";
                            break;
                        case 2:
                            twoText.text = "Bye";
                            if (!courrutine)
                            {
                                StartCoroutine(WaitForConversation(3));
                            }
                            oneText.text = "I hope I will never see you again";
                            if (!courrutine)
                            {
                                StartCoroutine(WaitForConversation(3));
                            }
                            twoText.text = "Uh lala";
                            break;
                    }
                }
            }
            else { GetComponent<TextMesh>().text = "You are to far"; }
            isTalking = false;
            scr.isTalking = true;
        } 
    }

    IEnumerator WaitForConversation(int sec) {
        courrutine = true;
        yield return new WaitForSeconds(sec);
        courrutine = false;
    }

    void Conversation()
    {
        int rnd = UnityEngine.Random.Range(0, 2);
        switch (rnd)
        {
            case 0:
                oneText.text = "You are beautiful";
                twoText.text = "You're not, sry :)";
                break;
            case 1:
                oneText.text = "Hellow";
                twoText.text = "Hi";
                break;
            case 2:
                oneText.text = "Bye";
                twoText.text = "I hope I will never see you again";
                break;
        }
    }
}
