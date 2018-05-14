using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using UnityEngine.UI;
using System.Linq;

public class LoverBehaviour : MonoBehaviour
{

    private Animator anim;
    private float waking;
    private float turning;
    private string[] phrases;

    private Vector3 offsetToDrunk;

    //deathTime is the time interval that is going to call "Deth"
    public float deathTime = 1f;

    //Variables to the movement
    private bool flag1, flag2, isTalking;
    public int turnspeed;
    public GameObject drunk;
    //public ConversationScript conversation;

    public GameObject two;

    private TextMesh oneText;
    private TextMesh twoText;

    //*******************************
    //for the boubvle text
    //*******************************
    public Vector3 rotation;
    Ray ray;
    RaycastHit hit;
    public GameObject vCurrentBubble = null; //just to make sure we cannot open multiple bubble at the same time.
    public bool IsTalking = false;
    public List<PixelBubble> vBubble = new List<PixelBubble>();
    private PixelBubble vActiveBubble = null;
    public GameObject BubbleRectangle;
    public GameObject BubbleRound;

    // Use this for initialization
    void Start()
    {
        oneText = GetComponent<TextMesh>();
        anim = GetComponent<Animator>();
        waking = 0.0f;
        turning = 0.0f;

        flag1 = true;
        flag2 = true;
        isTalking = false;

        phrases = new string[] { "Hi", "I love you baby", "Call me pls" };
        InvokeRepeating("Talk", deathTime, deathTime);

        PixelBubble asd = new PixelBubble();
        asd.vMessage = "Funcionará asi?";
        vBubble.Add(asd);
    }

    // Update is called once per frame
    void Update()
    {
        //check if we have the mouse over the character
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //make sure we left click and is on a NPC
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            //only return NPC
            if (hit.transform == this.transform)
            {
                //check the bubble on the character and make it appear!
                if (vBubble.Count > 0)
                {
                    ShowBubble(hit.transform.GetComponent<DialogBubble>());
                }
            }
        }

        //can't have a current character 
        if (!IsTalking)
        {
            vActiveBubble = null;
        }

        //*********************************************
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
        if (!isTalking)
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
            //scr.transform.position = 4;


            if (distance < 5)
            {
                if (twoText != null)
                {
                    StartCoroutine(StopMov(4, twoText, scr));
                }
            }
            else { GetComponent<TextMesh>().text = "You are to far"; }
        }
    }

    IEnumerator StopMov(float sec, TextMesh twoText, DrukBehaviour scr)
    {
        isTalking = true;
        scr.isTalking = true;

        int rnd = UnityEngine.Random.Range(0, 3);
        switch (rnd)
        {
            case 0:
                twoText.text = "You are beautiful";
                yield return new WaitForSeconds(sec);
                oneText.text = "You're not, sry :)";
                yield return new WaitForSeconds(sec);
                twoText.text = "So sad";
                break;
            case 1:
                twoText.text = "Hellow";
                yield return new WaitForSeconds(sec);
                oneText.text = "Hi";
                yield return new WaitForSeconds(sec);
                twoText.text = "See you later aligater";
                break;
            case 2:
                twoText.text = "Bye";
                yield return new WaitForSeconds(sec);
                oneText.text = "I hope I will never see you again";
                yield return new WaitForSeconds(sec);
                twoText.text = "Uh lala";
                break;

        }

        isTalking = false;
        scr.isTalking = false;
    }
    //show the right bubble on the current character
    void ShowBubble(DialogBubble vcharacter)
    {
        bool gotonextbubble = false;

        //if vcurrentbubble is still there, just close it
        if (vActiveBubble != null)
        {
            if (vActiveBubble.vClickToCloseBubble)
            {
                //get the function to close bubble
                Appear vAppear = vcharacter.vCurrentBubble.GetComponent<Appear>();
                vAppear.valpha = 0f;
                vAppear.vTimer = 0f; //instantly
                vAppear.vchoice = false; //close bubble

                //check if last bubble
                if (vActiveBubble == vcharacter.vBubble.Last())
                    vcharacter.IsTalking = false;
            }
        }

        foreach (PixelBubble vBubble in vcharacter.vBubble)
        {
            //make sure the bubble isn't already opened
            if (vcharacter.vCurrentBubble == null)
            {
                //make the character in talking status
                vcharacter.IsTalking = true;

                //cut the message into 24 characters
                string vTrueMessage = "";
                string cLine = "";
                int vLimit = 24;
                if (vBubble.vMessageForm == BubbleType.Round)
                    vLimit = 16;

                //cut each word in a text in 24 characters.
                foreach (string vWord in vBubble.vMessage.Split(' '))
                {
                    if (cLine.Length + vWord.Length > vLimit)
                    {
                        vTrueMessage += cLine + System.Environment.NewLine;

                        //add a line break after
                        cLine = ""; //then reset the current line
                    }

                    //add the current word with a space
                    cLine += vWord + " ";
                }

                //add the last word
                vTrueMessage += cLine;
                GameObject vBubbleObject = null;


                //create a rectangle or round bubble
                if (vBubble.vMessageForm == BubbleType.Rectangle)
                {
                    //create bubble
                    vBubbleObject = Instantiate(BubbleRectangle);
                    vBubbleObject.transform.Rotate(rotation); //Rotación de burbuja
                    vBubbleObject.transform.position = vcharacter.transform.position + new Vector3(1.35f, 1.9f, 0f); //move a little bit the teleport particle effect
                }
                else
                {
                    //create bubble
                    vBubbleObject = Instantiate(BubbleRound);
                    vBubbleObject.transform.position = vcharacter.transform.position + new Vector3(0.15f, 1.75f, 0f); //move a little bit the teleport particle effect
                }

                //show the mouse and wait for the user to left click OR NOT (if not, after 10 sec, it disappear)
                vBubbleObject.GetComponent<Appear>().needtoclick = vBubble.vClickToCloseBubble;

                Color vNewBodyColor = new Color(vBubble.vBodyColor.r, vBubble.vBodyColor.g, vBubble.vBodyColor.b, 0f);
                Color vNewBorderColor = new Color(vBubble.vBorderColor.r, vBubble.vBorderColor.g, vBubble.vBorderColor.b, 0f);
                Color vNewFontColor = new Color(vBubble.vFontColor.r, vBubble.vFontColor.g, vBubble.vFontColor.b, 255f);

                //get all image below the main Object
                foreach (Transform child in vBubbleObject.transform)
                {
                    SpriteRenderer vRenderer = child.GetComponent<SpriteRenderer>();
                    TextMesh vTextMesh = child.GetComponent<TextMesh>();

                    if (vRenderer != null && child.name.Contains("Body"))
                    {
                        //change the body color
                        vRenderer.color = vNewBodyColor;

                        if (vRenderer.sortingOrder < 10)
                            vRenderer.sortingOrder = 1500;
                    }
                    else if (vRenderer != null && child.name.Contains("Border"))
                    {
                        //change the border color
                        vRenderer.color = vNewBorderColor;
                        if (vRenderer.sortingOrder < 10)
                            vRenderer.sortingOrder = 1501;
                    }
                    else if (vTextMesh != null && child.name.Contains("Message"))
                    {
                        //change the message and show it in front of everything
                        vTextMesh.color = vNewFontColor;
                        vTextMesh.text = vTrueMessage;
                        child.GetComponent<MeshRenderer>().sortingOrder = 1550;

                        Transform vMouseIcon = child.FindChild("MouseIcon");
                        if (vMouseIcon != null && !vBubble.vClickToCloseBubble)
                            vMouseIcon.gameObject.SetActive(false);
                    }

                    //disable the mouse icon because it will close by itself
                    if (child.name == "MouseIcon" && !vBubble.vClickToCloseBubble)
                        child.gameObject.SetActive(false);
                    else
                        vActiveBubble = vBubble; //keep the active bubble and wait for the Left Click
                }

                vcharacter.vCurrentBubble = vBubbleObject; //attach it to the player
                vBubbleObject.transform.parent = vcharacter.transform; //make him his parent
            }
            else if (vActiveBubble == vBubble && vActiveBubble.vClickToCloseBubble)
            {
                gotonextbubble = true;
                vcharacter.vCurrentBubble = null;
            }
        }
    }

}

