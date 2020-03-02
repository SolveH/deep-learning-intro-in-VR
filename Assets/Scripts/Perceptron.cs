using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perceptron : MonoBehaviour
{
    public GameObject door;
    private SlideDoor slideDoorScript;

    public Material red;
    public Material green;
    public List<GameObject> outputElements;

    [SerializeField]
    private int bias = 3;
    [SerializeField]
    private int w1 = -2;
    [SerializeField]
    private int w2 = -2;
    private int x1 = 999;
    private int x2 = 999;

    private int previousOutput = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        slideDoorScript = door.GetComponent<SlideDoor>();
    }

    // Update is called once per frame
    void Update()
    {
        //should probably not do this in this loop
        if(calculateOutput() == 1 && previousOutput == 0)
        {
            slideDoorScript.OpenDoor();
            foreach (GameObject o in outputElements)
            {
                o.GetComponent<Renderer>().material = green;
            }
            previousOutput = 1;
        }
        else if(calculateOutput() == 0 && previousOutput == 1)
        {
            slideDoorScript.CloseDoor();
            foreach (GameObject o in outputElements)
            {
                o.GetComponent<Renderer>().material = red;
            }
            previousOutput = 0;
        }
    }

    public void input1Snapped(GameObject input)
    {
        x1 = input.GetComponent<NNInput>().getInputValue();
    }

    public void input1UnSnapped()
    {
        x1 = 999;
    }

    public void input2Snapped(GameObject input)
    {
        x2 = input.GetComponent<NNInput>().getInputValue();
    }

    public void input2UnSnapped()
    {
        x2 = 999;
    }

    private int calculateOutput()
    {
        if ((w1 * x1) + (w2 * x2) + bias > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
