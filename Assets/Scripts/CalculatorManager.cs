using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CalculatorManager : MonoBehaviour
{
    public TMP_Text outputText;
    public TMP_Text sigmoidOutputText;
    private string currentText = "";
    private AudioSource beepAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        beepAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed(string buttonContent)
    {
        beepAudioSource.Play();
        if(buttonContent == "del")
        {
            currentText = currentText.Substring(0, currentText.Length - 1);

        }
        else if (buttonContent == "calc")
        {
            if (currentText.Length > 0 && StringContainsChar(currentText))
            {
                Double inputValue = Convert.ToDouble(currentText);
                Double sigmoidValue = CalculateFourDecimalSigmoidValue(inputValue);
                sigmoidOutputText.text = sigmoidValue.ToString();
            }
        }
        else if (currentText.Length <= 4)
        {
            if (buttonContent == ".")
            {
                if (!currentText.Contains(".") && currentText.Length > 0)
                {
                    currentText = currentText + buttonContent;
                }
            }
            else if (buttonContent == "-")
            {
                if (currentText.Length == 0)
                {
                    currentText = currentText + "-";
                }
            }
            else
            {
                currentText = currentText + buttonContent;
            }
        }
        else
        {
            //Text is full
        }
        
        outputText.text = currentText;
    }

    private Boolean StringContainsChar(string inputString)
    {
        foreach(char c in inputString)
        {
            if (Char.IsDigit(c))
            {
                return true;
            }
        }
        return false;
    }

    private Double CalculateFourDecimalSigmoidValue (Double inputValue)
    {
        Double sigmoidValue = 1 / (1 + Math.Exp(-inputValue));
        sigmoidValue = Math.Round(sigmoidValue, 4);
        return sigmoidValue;
    }
}
