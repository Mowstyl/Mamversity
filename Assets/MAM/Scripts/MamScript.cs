using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Models;
using NUnit.Framework;
using Resources;
using UnityEngine;
using UnityEngine.UI;

public class MamScript : MonoBehaviour
{
    public Transform canvas;
    Text hText, qText;
    Text txtOption1, txtOption2, txtOption3, txtOption4;
    Button btnOption1, btnOption2, btnOption3, btnOption4, btnEnd;
    string q, a1, a2, a3, a4;


    private Question mainQuestion;
    private Answer selectedAnswer = null;
    
    private void Start()
    {
        Create();
        mainQuestion = CreateQA();
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Create();
            }
            else
            {
                canvas.gameObject.SetActive(false);
                hText.text = string.Empty;
            }
        }

    }

    private void EndCallOnClick()
    {
        if (canvas.gameObject.activeInHierarchy == true)
        {
            canvas.gameObject.SetActive(false);
            hText.text = String.Empty;
        }
    }

    #region Button Listeners
    private void Option1OnClick()
    {
        //Changing sslected Answer and mainQuestion
        selectedAnswer = mainQuestion.answers[0];

        if (selectedAnswer.question != null)
        {
            mainQuestion = selectedAnswer.question;
            UpdateUI();
        }
        else
            EndCallOnClick();
        
    }

    private void Option2OnClick()
    {
        selectedAnswer = mainQuestion.answers[1];
        if (selectedAnswer.question != null)
        {
            mainQuestion = selectedAnswer.question;
            UpdateUI();
        }
        else
            EndCallOnClick();
    }

    private void Option3OnClick()
    {
        selectedAnswer = mainQuestion.answers[2];
        if (selectedAnswer.question != null)
        {
            mainQuestion = selectedAnswer.question;
            UpdateUI();
        }
        else
            EndCallOnClick();    
    }

    private void Option4OnClick()
    {
        selectedAnswer = mainQuestion.answers[3];
        if (selectedAnswer.question != null)
        {
            mainQuestion = selectedAnswer.question;
            UpdateUI();
        }
        else
            EndCallOnClick();
    }

    #endregion

    private void UpdateUI()
    {
        qText.text = mainQuestion.text; 
        txtOption1.text= mainQuestion.answers[0].text;
        txtOption2.text= mainQuestion.answers[1].text;
        txtOption3.text= mainQuestion.answers[2].text;
        txtOption4.text= mainQuestion.answers[3].text;
    }

    //#region DangerZone
    private void Create()
    {
        hText = GameObject.Find("History").GetComponent<Text>();
        qText = GameObject.Find("MamQuestion").GetComponent<Text>();
        txtOption1 = GameObject.Find("Option1").GetComponent<Text>();
        txtOption2 = GameObject.Find("Option2").GetComponent<Text>();
        txtOption3 = GameObject.Find("Option3").GetComponent<Text>();
        txtOption4 = GameObject.Find("Option4").GetComponent<Text>();
        btnOption1 = GameObject.Find("btnOption1").GetComponent<Button>();
        btnOption2 = GameObject.Find("btnOption2").GetComponent<Button>();
        btnOption3 = GameObject.Find("btnOption3").GetComponent<Button>();
        btnOption4 = GameObject.Find("btnOption4").GetComponent<Button>();
        btnEnd = GameObject.Find("EndCall").GetComponent<Button>();
        btnOption1.onClick.AddListener(Option1OnClick);
        btnOption2.onClick.AddListener(Option2OnClick);
        btnOption3.onClick.AddListener(Option3OnClick);
        btnOption4.onClick.AddListener(Option4OnClick);
        btnEnd.onClick.AddListener(EndCallOnClick);
        //Example();
        
        
    }

    private Question CreateQA()
    {
        //Answers 
        // Level 2
        Answer a00 = new Answer(StringList.A00, null);
        Answer a01 = new Answer(StringList.A01, null);
        Answer a02 = new Answer(StringList.A02, null);
        Answer a03 = new Answer(StringList.A03, null);
            
        List<Answer> a0list = new List<Answer>();
        a0list.Add(a00);
        a0list.Add(a01);
        a0list.Add(a02);
        a0list.Add(a03);
            
        Answer a10 = new Answer(StringList.A10, null);
        Answer a11 = new Answer(StringList.A11, null);
        Answer a12 = new Answer(StringList.A12, null);
        Answer a13 = new Answer(StringList.A13, null);
        
        List<Answer> a1list = new List<Answer>();
        a1list.Add(a10);
        a1list.Add(a11);
        a1list.Add(a12);
        a1list.Add(a13);

        
        Answer a20 = new Answer(StringList.A20, null);
        Answer a21 = new Answer(StringList.A21, null);
        Answer a22 = new Answer(StringList.A22, null);
        Answer a23 = new Answer(StringList.A23, null);
            
        List<Answer> a2list = new List<Answer>();
        a2list.Add(a20);
        a2list.Add(a21);
        a2list.Add(a22);
        a2list.Add(a23);

        
        Answer a30 = new Answer(StringList.A30, null);
        Answer a31 = new Answer(StringList.A31, null);
        Answer a32 = new Answer(StringList.A32, null);
        Answer a33 = new Answer(StringList.A33, null);
        
        List<Answer> a3list = new List<Answer>();
        a3list.Add(a00);
        a3list.Add(a01);
        a3list.Add(a02);
        a3list.Add(a03);

        //Questions
        Question q0 = new Question(StringList.Q0,a0list);
        Question q1 = new Question(StringList.Q1, a1list);
        Question q2 = new Question(StringList.Q2, a2list);
        Question q3 = new Question(StringList.Q3, a3list);
        
        //Level 1
        
        //Answers
        Answer a0 = new Answer(StringList.A0,q0);
        Answer a1 = new Answer(StringList.A1,q1);
        Answer a2 = new Answer(StringList.A2,q2);
        Answer a3 = new Answer(StringList.A3,q3);
        
        List<Answer> aIlist = new List<Answer>();
        aIlist.Add(a0);
        aIlist.Add(a1);
        aIlist.Add(a2);
        aIlist.Add(a3);
        
        Question qI = new Question(StringList.QI,aIlist);

        return qI;

    }
    /*
     
     private void Example()
     {
         var rnd = new System.Random();
         q = "Question N" + rnd.Next(1, 100);
         a1 = "Answer N" + rnd.Next(1, 100);
         a2 = "Answer N" + rnd.Next(1, 100);
         a3 = "Answer N" + rnd.Next(1, 100);
         a4 = "Answer N" + rnd.Next(1, 100);
         txtOption1.text = a1;
         txtOption2.text = a2;
         txtOption3.text = a3;
         txtOption4.text = a4;
         qText.text = q;
     }
 
 
     #endregion
     */
    
    
}