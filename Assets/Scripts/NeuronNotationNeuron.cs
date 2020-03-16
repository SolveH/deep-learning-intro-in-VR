using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NeuronNotationNeuron : MonoBehaviour
{
    public int neuronLayer;
    public int neuronIndex;

    // Start is called before the first frame update
    void Start()
    {
        TMP_Text indicesText;
        foreach (TMP_Text text in GetComponentsInChildren<TMP_Text>())
        {
            if(text.name == "Indices")
            {
                indicesText = text;
                indicesText.text = "" + neuronLayer + "\n" + neuronIndex;
                break;
            }
        }
}
    
    public int getNeuronLayer()
    {
        return neuronLayer;
    }
    public int getNeuronIndex()
    {
        return neuronIndex;
    }
}
