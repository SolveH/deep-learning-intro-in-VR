using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletButtonPressed : MonoBehaviour
{
    public string buttonType;
    private CalculatorManager calcManager;

    private void Start()
    {
        calcManager = GetComponentInParent<CalculatorManager>();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //This happened because both was on the PokeLayer
        calcManager.ButtonPressed(buttonType);
    }
}
