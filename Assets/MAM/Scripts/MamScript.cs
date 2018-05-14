using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.MAM.Scripts;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class MamScript : MonoBehaviour
{
    public Transform canvas;
    Text hText, qText;
    Text txtOption1, txtOption2, txtOption3, txtOption4;
    Button btnOption1, btnOption2, btnOption3, btnOption4, btnEnd;
    MamService mamService;
    Answer selectedAnswer;

    
    private void Start()
    {
        mamService = new MamService();
        Create();
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                mamService = new MamService();
                Create();
                UpdateUI();
            }
            else
            {
                canvas.gameObject.SetActive(false);
                hText.text = string.Empty;
            }
        }

    }

    #region Button Listeners
    private void Option1OnClick()
    {
        UpdateUI();
    }

    private void Option2OnClick()
    {
        UpdateUI();
    }

    private void Option3OnClick()
    {
        UpdateUI();
    }

    private void Option4OnClick()
    {
        UpdateUI();
    }

    private void EndCallOnClick()
    {
        if (canvas.gameObject.activeInHierarchy == true)
        {
            canvas.gameObject.SetActive(false);
            hText.text = String.Empty;
        }
    }

    #endregion

    private void UpdateUI()
    {
        Question q = mamService.GetQuestion();

        if (q == null)
        {
            qText.text = "[End of conversation]";
            canvas.gameObject.SetActive(false);

        }
        else
        {
            qText.text = q.text;
            if (q.answers.Count >= 4)
            {
                txtOption1.text = q.answers[0].text;
                txtOption2.text = q.answers[1].text;
                txtOption3.text = q.answers[2].text;
                txtOption4.text = q.answers[3].text;
            }
            else if (q.answers.Count == 3)
            {
                txtOption1.text = q.answers[0].text;
                txtOption2.text = q.answers[1].text;
                txtOption3.text = q.answers[2].text;
                txtOption4.text = "";
            }
            else if (q.answers.Count == 2)
            {
                txtOption1.text = q.answers[0].text;
                txtOption2.text = q.answers[1].text;
                txtOption3.text = "";
                txtOption4.text = "";
            }
            else if (q.answers.Count == 1)
            {
                txtOption1.text = q.answers[0].text;
                txtOption2.text = "";
                txtOption3.text = "";
                txtOption4.text = "";
            }
            else
            {
                qText.text = "[End of conversation]";
            }
        }
    }

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
        txtOption1.text = txtOption2.text = txtOption3.text = txtOption4.text = "";
    }
}