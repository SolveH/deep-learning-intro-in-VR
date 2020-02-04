using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perceptron : MonoBehaviour
{
    public GameObject door;
    private Animator animator;

    [SerializeField]
    private int bias = 3;
    [SerializeField]
    private int w1 = -2;
    [SerializeField]
    private int w2 = -2;
    private int x1 = 999;
    private int x2 = 999;

    

    // Start is called before the first frame update
    void Start()
    {
        animator = door.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(calculateOutput() == 1)
        {
            animator.SetTrigger("TaskSolved");
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
