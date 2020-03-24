using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TermRelationHandler : MonoBehaviour
{
    public GameObject chainRuleInfoSheet;

    private int correctTermCount;
    private AudioSource winAudio;

    // Start is called before the first frame update
    void Start()
    {
        correctTermCount = 0;
        AudioSource[] audioSources = GetComponents<AudioSource>();
        winAudio = audioSources[0];
    }

    public void addCorrectTerm()
    {
        correctTermCount++;
        if(correctTermCount == 7)
        {
            chainRuleInfoSheet.SetActive(true);
            winAudio.Play();
        }
    }
    public void removeCorrectTerm()
    {
        correctTermCount--;
    }
}
