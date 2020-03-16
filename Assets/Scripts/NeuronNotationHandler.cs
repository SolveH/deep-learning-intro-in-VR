using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuronNotationHandler : MonoBehaviour
{
    public int neuronAmount;
    public SlideDoor slideDoor;

    private int correctNeuronsPlaced = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void CheckCorrectNeuronsPlacedAmount()
    {
        if(correctNeuronsPlaced == neuronAmount)
        {
            slideDoor.OpenDoor();
        }
        else
        {
            if (!slideDoor.CheckClosed())
            {
                slideDoor.CloseDoor();
            }
        }
    }

    public void CorrectNeuronAdded()
    {
        correctNeuronsPlaced++;
        CheckCorrectNeuronsPlacedAmount();
    }
    public void CorrectNeuronRemoved()
    {
        correctNeuronsPlaced--;
        CheckCorrectNeuronsPlacedAmount();
    }
}
