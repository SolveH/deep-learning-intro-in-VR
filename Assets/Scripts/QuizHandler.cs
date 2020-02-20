using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using QuickType;

public class QuizHandler : MonoBehaviour
{
    public Canvas canvas;

    private TMP_Text questionNumberText;
    private TMP_Text questionText;
    private TMP_Text answer1Text;
    private TMP_Text answer2Text;
    private TMP_Text answer3Text;
    private TMP_Text answer4Text;


    private bool cartridgeInserted = false;
    private CartridgeJSONReader cartridgeScript;
    private Question[] questions;
    private int totalQuestions = 5;

    private int currentQuestionNumber = 0;


    // Start is called before the first frame update
    void Awake()
    {
        foreach(TMP_Text text in canvas.GetComponentsInChildren<TMP_Text>())
        {
            switch (text.name)
            {
                case "Question":
                    questionText = text;
                    break;
                case "Question number":
                    questionNumberText = text;
                    break;
                case "Answer 1":
                    answer1Text = text;
                    break;
                case "Answer 2":
                    answer2Text = text;
                    break;
                case "Answer 3":
                    answer3Text = text;
                    break;
                case "Answer 4":
                    answer4Text = text;
                    break;
                default:
                    Debug.Log("Found an unexpected text element inside quiz canvas. Name: " + text.name);
                    break;
            }
        }
    }

    private void SetQuestion(int qNum, string question, string[] answers)
    {
        questionNumberText.text = qNum.ToString() + "/" + totalQuestions.ToString();
        questionText.text = question;

        int answerCount = answers.Length;
        List<string> answersWithEmptyStrings = new List<string>();
        foreach(string answer in answers)
        {
            answersWithEmptyStrings.Add(answer);
        }
        while(answersWithEmptyStrings.Count < 4)
        {
            answersWithEmptyStrings.Add("");
        }
        answer1Text.text = answersWithEmptyStrings[0];
        answer2Text.text = answersWithEmptyStrings[1];
        answer3Text.text = answersWithEmptyStrings[2];
        answer4Text.text = answersWithEmptyStrings[3];
    }

    public void InsertCartridge(GameObject input)
    {
        cartridgeInserted = true;
        cartridgeScript = input.GetComponent<CartridgeJSONReader>();
        questions = cartridgeScript.GetQuestions();
        currentQuestionNumber = 0;
        totalQuestions = questions.Length - 1;

        StartQuiz();
        
    }
    public void EjectCartridge(GameObject input)
    {
        cartridgeInserted = false;
    }

    private void StartQuiz()
    {
        Question q = questions[0];
        SetQuestion(currentQuestionNumber + 1, q.Questiontext, q.Answers);
    }
    private void NextQuestion()
    {
        if(currentQuestionNumber < totalQuestions)
        {
            currentQuestionNumber += 1;
            Question q = questions[currentQuestionNumber];
            SetQuestion(currentQuestionNumber + 1, q.Questiontext, q.Answers);
        }else
        {
            cartridgeScript.CompletedCartridge();
        }
    }
    private bool CheckAnswerCorrect(int answerNumber)
    {
        foreach(int correctAnswerNumber in questions[currentQuestionNumber].Correctanswers)
        {
            if(answerNumber == correctAnswerNumber)
            {
                return true;
            }
        }
        return false;   
    }

    public void HandleButtonInput(int buttonNumber)
    {
        Debug.Log("Got button input: " + buttonNumber);
        if (CheckAnswerCorrect(buttonNumber))
        {
            NextQuestion();
        }
    }
}
