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
    int maxReward, reward;
    Text txtOption1, txtOption2, txtOption3, txtOption4, qText, rewardText;
    Button btnOption1, btnOption2, btnOption3, btnOption4, btnEnd;
    MamService mamService;
    Question currentQuestion;


    private void Start()
    {
        MamLoad();
        Create();
        UpdateUI();
    }

    private void MamLoad()
    {
        mamService = new MamService();
        currentQuestion = new Question();
        maxReward = mamService.numQuestions * 10;
        reward = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                MamLoad();
                CleanUI();
                UpdateUI();
            }
            else
            {
                canvas.gameObject.SetActive(false);
            }
        }

    }

    private void CleanUI()
    {
        txtOption1.text = txtOption2.text = txtOption3.text = txtOption4.text = "";
        rewardText.text = "";
    }

    #region Button Listeners
    private void Option1OnClick()
    {
        if (currentQuestion != null && currentQuestion.answers.Count() > 0)
        {
            reward += currentQuestion.answers[0].reward;
            UpdateUI();
        }
    }

    private void Option2OnClick()
    {
        if (currentQuestion != null && currentQuestion.answers.Count() > 1)
        {
            reward += currentQuestion.answers[1].reward;
            UpdateUI();
        }
    }

    private void Option3OnClick()
    {
        if (currentQuestion != null && currentQuestion.answers.Count() > 2)
        {
            reward += currentQuestion.answers[2].reward;
            UpdateUI();
        }
    }

    private void Option4OnClick()
    {
        if (currentQuestion != null && currentQuestion.answers.Count() > 3)
        {
            reward += currentQuestion.answers[3].reward;
            UpdateUI();
        }
    }

    private void EndCallOnClick()
    {
        if (canvas.gameObject.activeInHierarchy == true)
        {
            canvas.gameObject.SetActive(false);
        }
    }

    #endregion

    private void UpdateUI()
    {
        currentQuestion = mamService.GetQuestion();

        if (currentQuestion == null)
        {
            qText.text = "[End of conversation]";
            txtOption1.text = txtOption2.text = txtOption3.text = txtOption4.text = "";
            GetScore();

        }
        else
        {
            qText.text = currentQuestion.text;
            if (currentQuestion.answers.Count >= 4)
            {
                txtOption1.text = currentQuestion.answers[0].text;
                txtOption2.text = currentQuestion.answers[1].text;
                txtOption3.text = currentQuestion.answers[2].text;
                txtOption4.text = currentQuestion.answers[3].text;
            }
            else if (currentQuestion.answers.Count == 3)
            {
                txtOption1.text = currentQuestion.answers[0].text;
                txtOption2.text = currentQuestion.answers[1].text;
                txtOption3.text = currentQuestion.answers[2].text;
                txtOption4.text = "";
            }
            else if (currentQuestion.answers.Count == 2)
            {
                txtOption1.text = currentQuestion.answers[0].text;
                txtOption2.text = currentQuestion.answers[1].text;
                txtOption3.text = "";
                txtOption4.text = "";
            }
            else if (currentQuestion.answers.Count == 1)
            {
                txtOption1.text = currentQuestion.answers[0].text;
                txtOption2.text = "";
                txtOption3.text = "";
                txtOption4.text = "";
            }
            else
            {
                qText.text = "[End of conversation]";
                txtOption1.text = "";
                txtOption2.text = "";
                txtOption3.text = "";
                txtOption4.text = "";
            }
        }
    }

    private void GetScore()
    {
        reward = ((reward * 100) / maxReward);
        rewardText.text = reward + "%";
    }

    private void Create()
    {
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
        rewardText = GameObject.Find("rewardText").GetComponent<Text>();
        btnOption1.onClick.AddListener(Option1OnClick);
        btnOption2.onClick.AddListener(Option2OnClick);
        btnOption3.onClick.AddListener(Option3OnClick);
        btnOption4.onClick.AddListener(Option4OnClick);
        btnEnd.onClick.AddListener(EndCallOnClick);
    }
}