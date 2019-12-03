using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveHandler : MonoBehaviour
{
    //General objects
    public GameObject roof;

    //Coffee objects
    public GameObject coffeeSnapZone;
    public TMP_Text tv_text;

    //Teleport objects
    public GameObject teleportTarget;
    public TMP_Text teleport_text;

    void Start()
    {
        roof.SetActive(true);
    }

    void Update()
    {
        
    }

    public void firstGrabbedCoffee()
    {
        coffeeSnapZone.SetActive(true);
        tv_text.text = "Put the coffee cup in the coffee machine";
        
    }

    public void coffeeSnapped()
    {
        tv_text.text = "Turn left";
        teleportTarget.SetActive(true);
        teleport_text.text = "Hold your thumb on the joystick and point at the teleport target";
    }

    public void teleportTargetEntered()
    {
        teleport_text.text = "Press the joystick down while pointing at teleport target";
    }
}
