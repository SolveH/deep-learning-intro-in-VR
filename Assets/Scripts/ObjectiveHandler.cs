using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveHandler : MonoBehaviour
{
    public GameObject coffeeSnapZone;
    public TMP_Text text;
    public GameObject interactableCoffecup;

    void Update()
    {
        if(interactableCoffecup.transform.position.y < 0.2)
        {
            interactableCoffecup.transform.position = new Vector3(2.023f, 0.943f, -2.896f);
        }
    }

    public void firstGrabbedCoffee()
    {
        coffeeSnapZone.SetActive(true);
        text.text = "Put the coffee cup in the coffee machine";
        
    }
}
