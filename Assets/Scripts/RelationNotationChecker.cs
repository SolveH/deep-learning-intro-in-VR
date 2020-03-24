using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationNotationChecker : MonoBehaviour
{
    public string correctTerm;
    private AudioSource incorrectAudio;
    private AudioSource correctAudio;
    private TermRelationHandler termRelationHandler;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        correctAudio = audioSources[0];
        incorrectAudio = audioSources[1];
        termRelationHandler = GetComponentInParent<TermRelationHandler>();
    }

    public void insertTerm(GameObject termCube)
    {
        RelationNotationTerm termCubeScript = termCube.GetComponent<RelationNotationTerm>();
        string insertedTerm = termCubeScript.getTerm();
        if(correctTerm == insertedTerm)
        {
            correctAudio.Play();
            termRelationHandler.addCorrectTerm();
        }
        else
        {
            incorrectAudio.Play();
        }
    }
    public void ejectTerm(GameObject termCube)
    {
        RelationNotationTerm termCubeScript = termCube.GetComponent<RelationNotationTerm>();
        string insertedTerm = termCubeScript.getTerm();
        if (correctTerm == insertedTerm)
        {
            termRelationHandler.removeCorrectTerm();
        }
    }
}
