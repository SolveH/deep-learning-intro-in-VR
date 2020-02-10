using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class NumpadLogic : MonoBehaviour
{
    public string winCode = "4236";
    protected string currentCode = "0000";
    public UnityEvent onWin;
    public TMPro.TextMeshProUGUI display;
    private AudioSource beepAudioSource;

    void Awake() {
        currentCode = display.text;
    }

    private void Start()
    {
        beepAudioSource = GetComponentInParent<AudioSource>();
    }

    public void ButtonPressed(int val) {
        beepAudioSource.Play();
        currentCode = currentCode.Substring(1) + val.ToString();
        display.text = currentCode;

        if (currentCode == winCode) {
            Debug.Log("WINNER!");
            if (onWin != null) {
                onWin.Invoke();
            }
        }
    }
}
