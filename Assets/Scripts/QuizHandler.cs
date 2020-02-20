using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private int totalQuestions = 5;


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

    private void SetQuestion(string qNum, string question, List<string> answers)
    {
        questionNumberText.text = qNum + "/" + totalQuestions.ToString();
        questionText.text = question;

        int answerCount = answers.Count;
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

    public void InsertCartridge()
    {
        cartridgeInserted = true;
    }
    public void EjectCartridge()
    {
        cartridgeInserted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
