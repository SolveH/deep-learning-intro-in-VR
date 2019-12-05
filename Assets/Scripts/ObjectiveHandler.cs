using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveHandler : MonoBehaviour
{
    //General objects
    public GameObject roof;
    public GameObject headsetAlias;

    //Coffee objects
    private bool task1finished = false;
    private bool task2finished = false;
    public GameObject coffeeSnapZone;
    public TMP_Text tv_text;

    //Teleport objects
    private bool task3finished = false;
    public GameObject teleportTV;
    public GameObject teleportTarget;
    public TMP_Text teleport_text;

    //Key objects
    public GameObject keygrabbingTVCanvas;
    public GameObject key;

    void Start()
    {
        roof.SetActive(true);
    }

    void Update()
    {
        //Disable teleport target and teleport tutorial TV when player is near teleport target 1
        //Also enable keygrab TV tutorial
        if (teleportTarget.activeSelf && !task3finished)
        {
            if (Vector3.Distance(headsetAlias.transform.position, teleportTarget.transform.position) < 3)
            {
                task3finished = true;
                teleport_text.text = "Unlock the door using the key";
                keygrabbingTVCanvas.SetActive(true);
            }
        }
    }

    public void FirstGrabbedCoffee()
    {
        task1finished = true;
        coffeeSnapZone.SetActive(true);
        tv_text.text = "Put the coffee cup in the coffee machine";
    }

    public void CoffeeSnapped()
    {
        task2finished = true;
        tv_text.text = "Turn left";
        teleportTarget.SetActive(true);
        teleport_text.text = "Pull the joystick forward and point at the teleport target";
    }

    public void TeleportTargetEntered()
    {
        if(!task3finished)
        {
            teleport_text.text = "Release the joystick to teleport";
        }
    }
}
