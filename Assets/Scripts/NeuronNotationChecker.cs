using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuronNotationChecker : MonoBehaviour
{
    public int layer;
    public int neuronIndex;

    private AudioSource incorrectAudio;
    private AudioSource correctAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        incorrectAudio = audioSources[0];
        correctAudio = audioSources[1];
        
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void insertNeuron(GameObject neuron)
    {
        NeuronNotationNeuron neuronScript = neuron.GetComponent<NeuronNotationNeuron>();
        if(neuronScript.getNeuronLayer() != layer || neuronScript.getNeuronIndex() != neuronIndex)
        {
            incorrectAudio.Play();
        }
        else
        {
            correctAudio.Play();
        }
    }
}
