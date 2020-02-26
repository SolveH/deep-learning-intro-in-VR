using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using QuickType;
using UnityEngine.Events;

public class CartridgeJSONReader : MonoBehaviour
{
    public string fileName;
    //public Material red;
    public Material green;
    public UnityEvent winEvent;

    private string path;
    private string jsonString;
    private Question[] questions;



    void Start()
    {
        //add try catching
        path = Application.streamingAssetsPath + "/" + fileName;
        UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(path);
        www.SendWebRequest();
        while (!www.isDone)
        { 
            //wait
        }
        jsonString = www.downloadHandler.text;
        questions = Cartridge.FromJson(jsonString).Data;
        //Debug.Log("There is no file with the name: ''" + fileName + "''. \n Exception text: " + e);
    }
    public Question[] GetQuestions()
    {
        return questions;
    }
    //Should probably have a boolean for checking if cartridge is complete or not. 
    public void CompletedCartridge()
    {
        foreach(Renderer r in GetComponentsInChildren<Renderer>())
        {
            if(r.name == "Cartridge")
            {
                r.material = green;
                winEvent.Invoke();
            }
        }
        
    }
}