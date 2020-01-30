using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button tutorialBtn;
    public Button room1Btn;

    private void Awake()
    {
        tutorialBtn.onClick.AddListener(() =>
        {
            SceneLoader.Load(SceneLoader.Scene.Tutorial);
        });

        room1Btn.onClick.AddListener(() =>
        {
            SceneLoader.Load(SceneLoader.Scene.Loading);
        });
    }
}
