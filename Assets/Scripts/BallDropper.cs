using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BallDropper : MonoBehaviour
{
    public GameObject ballPrefab;
    public TMP_Text gradientDescentValuesText;

    private List<Vector3> startPositions;

    private int currentBall = 0;

    // Start is called before the first frame update
    void Start()
    {
        startPositions = new List<Vector3>();
        startPositions.Add(new Vector3(-0.569f, 2.618f, 2.419f));
        startPositions.Add(new Vector3(1.977f, 3.098f, 2.333f));
        startPositions.Add(new Vector3(-1.023f, 2.922f, -2.026f));
        startPositions.Add(new Vector3(1.414f, 2.842f, -2.198f));
        startPositions.Add(new Vector3(0.036f, 2.442f, -0.71f));
    }

    // Update is called once per frame
    void Update()
    {
        GameObject ball = GameObject.Find("Gradient ball(Clone)");
        if (ball == null)
        {
            GameObject newBall = Instantiate(ballPrefab) as GameObject;
            newBall.transform.SetParent(this.transform);
            newBall.transform.localPosition = startPositions[currentBall];

            if(currentBall == startPositions.Count - 1)
            {
                currentBall = 0;
            }
            else
            {
                currentBall += 1;
            }

        }
        else
        {
            float ballX = Mathf.Round(ball.transform.localPosition.x * 100f) / 100f;
            float ballY = Mathf.Round(ball.transform.localPosition.z * 100f) / 100f;
            float functionCost = Mathf.Round((ball.transform.localPosition.y - 0.2578442f) * 100f) / 100f;
            gradientDescentValuesText.text = "x = " + ballX + "\n y = " + ballY + "\n C(x, y) = " + functionCost;
            if (ball.GetComponent<Rigidbody>().velocity.magnitude < 0.01f)
            {
                Destroy(ball);
            }
        }
        
    }
}