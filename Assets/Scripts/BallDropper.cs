using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDropper : MonoBehaviour
{
    public GameObject ballPrefab;

    private List<Vector3> startPositions;

    // Start is called before the first frame update
    void Start()
    {
        startPositions = new List<Vector3>();
        //startPositions.Add(new Vector3(4.399f, 4.3f, 4.191f));
        //startPositions.Add(new Vector3(1.266f, 4.3f, 4.802f));
        startPositions.Add(new Vector3(4.944f, 2.903f, 4.131f));
        //startPositions.Add(new Vector3(3.46f, 4.3f, 5.167f));
    }

    // Update is called once per frame
    void Update()
    {
        GameObject ball = GameObject.Find("Gradient ball(Clone)");
        if (ball == null)
        {
            GameObject newBall = Instantiate(ballPrefab) as GameObject;
            newBall.transform.SetParent(this.transform);
            newBall.transform.localPosition = startPositions[Random.Range(0, startPositions.Count)];

        }
        else
        {
            if(ball.GetComponent<Rigidbody>().velocity.magnitude < 0.1f)
            {
                //Destroy(ball);
            }
        }
    }
}