using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using QuickType;

public class CartridgeJSONReader : MonoBehaviour
{
    public string fileName;
    //public Material red;
    public Material green;

    private string path;
    private string jsonString;
    private Question[] questions;


    void Start()
    {
        try
        {
            path = Application.streamingAssetsPath + "/" + fileName;
            jsonString = File.ReadAllText(path);
            questions = Cartridge.FromJson(jsonString).Data;
        }catch(FileNotFoundException e)
        {
            Debug.Log("There is no file with the name: ''" + fileName + "''. \n Exception text: " + e);
        }
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
            }
        }
        
    }
}