using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPointing : MonoBehaviour
{
    public GameObject customHandLeft;
    public GameObject customHandRight;

    private Animator animatorLeft;
    private Animator animatorRight;

    // Start is called before the first frame update
    void Start()
    {
        animatorLeft = customHandLeft.GetComponentInChildren<Animator>();
        animatorRight = customHandRight.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
