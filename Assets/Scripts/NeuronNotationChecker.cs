using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuronNotationChecker : MonoBehaviour
{
    public int layer;
    public int neuronIndex;

    private NeuronNotationHandler neuronNotationHandler;
    private AudioSource incorrectAudio;
    private AudioSource correctAudio;
    
    
    // Start is called before the first frame update
    void Start()
    {
        neuronNotationHandler = GetComponentInParent<NeuronNotationHandler>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        incorrectAudio = audioSources[0];
        correctAudio = audioSources[1];
        
    }

    public void insertNeuron(GameObject neuron)
    {
        NeuronNotationNeuron neuronScript = neuron.GetComponent<NeuronNotationNeuron>();
        if(neuronScript.getNeuronLayer() == layer && neuronScript.getNeuronIndex() == neuronIndex)
        {
            neuronNotationHandler.CorrectNeuronAdded();
            correctAudio.Play();
        }
        else
        {
            incorrectAudio.Play();
        }
    }
    public void ejectNeuron(GameObject neuron)
    {
        NeuronNotationNeuron neuronScript = neuron.GetComponent<NeuronNotationNeuron>();
        if (neuronScript.getNeuronLayer() == layer && neuronScript.getNeuronIndex() == neuronIndex)
        {
            neuronNotationHandler.CorrectNeuronRemoved();
        }
    }
}
