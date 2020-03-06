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
    private TMP_Text pointsText;
    private TMP_Text helpText;
    private Image panel1;
    private Image panel2;
    private Image panel3;
    private Image panel4;

    private Color32 grey = new Color32(199, 199, 199, 255);
    private Color32 correctGreen = new Color32(0, 255, 0, 255);
    private Color32 incorrectRed = new Color32(255, 0, 0, 255);
    private Color32 correctNotChosenLightgreen = new Color32(191, 255, 194, 255);

    private Color32 quizBlue = new Color32(0, 19, 255, 155);
    private Color32 quizGreen = new Color32(10, 103, 0, 155);
    private Color32 quizRed = new Color32(231, 18, 0, 155);
    private Color32 quizPurple = new Color32(255, 6, 230, 155);

    private bool showAnswerScreen = false;

    private bool cartridgeInserted = false;
    private CartridgeJSONReader cartridgeScript;
    private Question[] questions;
    private int totalQuestions = 5;
    private int currentQuestionNumber = 0;
    private int points = 0;
    private bool currentCartridgeFinished = false;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(Image img in canvas.GetComponentsInChildren<Image>())
        {
            switch (img.name)
            {
                case "Answer panel 1":
                    panel1 = img;
                    break;
                case "Answer panel 2":
                    panel2 = img;
                    break;
                case "Answer panel 3":
                    panel3 = img;
                    break;
                case "Answer panel 4":
                    panel4 = img;
                    break;
                default:
                    Debug.Log("Found some other image in the answer panel, name: " + img.name);
                    break;
            }
        }

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
                case "Points":
                    pointsText = text;
                    break;
                case "Help text":
                    helpText = text;
                    break;
                default:
                    Debug.Log("Found an unexpected text element inside quiz canvas. Name: " + text.name);
                    break;
            }
        }
    }

    //Sets the screen to only show question
    private void SetQuestion(int qNum, string question, string[] answers)
    {
        questionNumberText.text = "#" +  qNum.ToString() + "/" + (totalQuestions+1).ToString();
        questionText.text = question;
        SetPointsText();

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
        helpText.text = "";
    }

    //Update points text
    private void SetPointsText()
    {
        pointsText.text = "Points: \n" + points;
    }

    //When cartridge is inserted, get the List of questions and display the first question
    public void InsertCartridge(GameObject input)
    {
        cartridgeInserted = true;
        cartridgeScript = input.GetComponent<CartridgeJSONReader>();
        questions = cartridgeScript.GetQuestions();
        currentQuestionNumber = 0;
        totalQuestions = questions.Length - 1;
        currentCartridgeFinished = false;

        points = 0;
        ResetPanelColors();
        StartQuiz();
        
    }

    public void EjectCartridge(GameObject input)
    {
        cartridgeInserted = false;
    }

    //Display first question. Nothing will happen until user gives input
    private void StartQuiz()
    {
        Question q = questions[0];
        SetQuestion(currentQuestionNumber + 1, q.Questiontext, q.Answers);
    }


    private void NextQuestion()
    {

        currentQuestionNumber += 1;
        Question q = questions[currentQuestionNumber];
        SetQuestion(currentQuestionNumber + 1, q.Questiontext, q.Answers);
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

    //Change the color of the alternatives to visualize if an answer is correct or not. 
    //The validated user input will be displayed in a stronger color
    private void DisplayAnswers(int userInput)
    {
        Question q = questions[currentQuestionNumber];
        List<int> correctAnswers = new List<int>(q.Correctanswers);
        ColorPanelWithCorrectColor(0, userInput, panel1, correctAnswers);
        ColorPanelWithCorrectColor(1, userInput, panel2, correctAnswers);
        ColorPanelWithCorrectColor(2, userInput, panel3, correctAnswers);
        ColorPanelWithCorrectColor(3, userInput, panel4, correctAnswers);
        helpText.color = grey;
        helpText.text = "The next question will display after 2 sec";
    }

    //Colors the corresponding answers panel to the correct color. 
    private void ColorPanelWithCorrectColor(int currentAnswer, int userInput, Image panel, List<int> correctAnswers)
    {
        //Check whether the current panel is one of the correct answers
        if (correctAnswers.Contains(currentAnswer))
        {
            //If the user also gave this answer, give a stronger green color. 
            if (userInput == currentAnswer)
                panel.color = correctGreen;
            //If not, give a lighter color to indicate that the answer is also correct. 
            else
                panel.color = correctNotChosenLightgreen;
        }
        else
        {
            //If the user gave an incorrect answer, give it a strong red color
            if (userInput == currentAnswer)
                panel.color = incorrectRed;
            //If not give it a light grey color
            else
                panel.color = grey;
        }
    }

    //Reset the panel colors to standard colors
    private void ResetPanelColors()
    {
        panel1.color = quizBlue;
        panel2.color = quizGreen;
        panel3.color = quizRed;
        panel4.color = quizPurple;
    }
    private bool CheckFinished()
    {
        if(currentQuestionNumber < totalQuestions)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private bool CheckEnoughPointsToWin()
    {
        float currentPercentage = (float)points / (float)(totalQuestions + 1);
        if(currentPercentage >= 0.8)
        {
            return true;
        }return false;
    }

    IEnumerator DisplayNextQuestionAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        showAnswerScreen = false;
        ResetPanelColors();
        NextQuestion();

    }

    public void HandleButtonInput(int buttonNumber)
    {
        Debug.Log("Got button input: " + buttonNumber);
        if (!currentCartridgeFinished) {
            if (!showAnswerScreen)
            {
                if (CheckAnswerCorrect(buttonNumber))
                {
                    points += 1;
                    SetPointsText();
                }

                showAnswerScreen = true;
                DisplayAnswers(buttonNumber);
                if (CheckFinished())
                {
                    if (CheckEnoughPointsToWin())
                    {
                        cartridgeScript.CompletedCartridge();
                        helpText.color = correctGreen;
                        helpText.text = "Congratulations! You won the quiz.";
                    }
                    else
                    {
                        helpText.color = incorrectRed;
                        int pointPercentage = (int)((float)points / (float)(totalQuestions + 1) * 100);
                        helpText.text = "You need to get 80% of the answers correct, but you got " + pointPercentage + "%. \n Reinsert the cartridge to try again.";
                    }
                    showAnswerScreen = false;
                    currentCartridgeFinished = true;
                }
                else
                {
                    StartCoroutine(DisplayNextQuestionAfterTime(2.0f));
                }
            }
        }
    }
}
