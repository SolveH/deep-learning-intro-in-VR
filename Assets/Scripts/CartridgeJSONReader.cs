using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using QuickType;
using UnityEngine.Events;
using OVRSimpleJSON;

public class CartridgeJSONReader : MonoBehaviour
{
    public string fileName;
    //public Material red;
    public Material green;
    public UnityEvent winEvent;

    private AudioSource winSound;
    private bool cartridgeCompleted = false;
    private string path;
    private string jsonString;
    private Question[] questions;



    void Start()
    {
        winSound = GetComponentInParent<AudioSource>();

        //add try catching for when file is not found?
        Debug.Log("STARTING TO READ JSON FILE!!!");
        
        /*if((Application.platform == RuntimePlatform.WindowsEditor) || (Application.platform == RuntimePlatform.OSXEditor))
        {
            
        }*/
        //Read on Oculus Quest
        if(Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("Inside android stuff");
            path = Path.Combine(Application.streamingAssetsPath, fileName);
            UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(path);
            www.SendWebRequest();
            while (!www.isDone)
            {
                //wait
            }
            jsonString = www.downloadHandler.text;
        }
        else
        {
            Debug.Log("Inside windowseditor stuff");
            path = Path.Combine(Application.streamingAssetsPath, fileName);
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    jsonString = reader.ReadToEnd();
                    //jsonString = File.ReadAllText(path);
                }
            }
        }


        questions = Cartridge.FromJson(jsonString).Data;
        
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
                winSound.Play();
                r.material = green;
                cartridgeCompleted = true;
                winEvent.Invoke();
            }
        }
    }
    public bool GetCartridgeCompleteStatus()
    {
        return cartridgeCompleted;
    }
}