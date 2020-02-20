using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using QuickType;

public class CartridgeJSONReader : MonoBehaviour
{
    public string fileName;
    private string path;
    private string jsonString;

    void Start()
    {
        try
        {
            path = Application.streamingAssetsPath + "/" + fileName;
            jsonString = File.ReadAllText(path);
            Question[] questions = Cartridge.FromJson(jsonString).Data;
            Debug.Log(questions[0].Questiontext);
        }catch(FileNotFoundException e)
        {
            Debug.Log("There is no file with the name: ''" + fileName + "''. \n Exception text: " + e);
        }
        
    }
}