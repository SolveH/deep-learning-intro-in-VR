using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainRuleNotationFormulaHandler : MonoBehaviour
{
    public GameObject informationTable;
    public SlideDoor slideDoor;

    private int correctFormulaCount;
    private AudioSource winAudio;

    // Start is called before the first frame update
    void Start()
    {
        correctFormulaCount = 0;
        AudioSource[] audioSources = GetComponents<AudioSource>();
        winAudio = audioSources[0];
    }

    public void addCorrectTerm()
    {
        correctFormulaCount++;
        if (correctFormulaCount == 7)
        {
            winAudio.Play();
            informationTable.SetActive(true);
            slideDoor.OpenDoor();
        }
    }
    public void removeCorrectTerm()
    {
        correctFormulaCount--;
    }
}
