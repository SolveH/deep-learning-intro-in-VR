using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public enum Scene
    {
        Tutorial,
        Room1,
    }

    public static void Load(Scene scene)
    {
        //Load Scene if it is not the current Scene. 
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName(scene.ToString()))
        {
            SceneManager.LoadScene(scene.ToString());
        }
        else
        {
            //TODO: Implement resume game here
        }
    }
}
