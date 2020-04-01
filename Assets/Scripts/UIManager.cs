using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button tutorialBtn;
    public Button room1Btn;
    public GameObject leftScreen;
    public GameObject midScreen;
    public GameObject rightScreen;

    public GameObject credits;
    private Animator creditsAnimator;

    private void Awake()
    {
        creditsAnimator = credits.GetComponent<Animator>();
        
        tutorialBtn.onClick.AddListener(() =>
        {
            SceneLoader.Load(SceneLoader.Scene.Tutorial);
        });

        room1Btn.onClick.AddListener(() =>
        {
            SceneLoader.Load(SceneLoader.Scene.Room1);
        });
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void OpenSurveyInBrowser()
    {
        Application.OpenURL("https://forms.gle/kxvfuiEaJCGM7bbE6");
    }

    public void PlaySubtitles()
    {
        creditsAnimator.SetTrigger("PlayCredits");
        leftScreen.SetActive(false);
        midScreen.SetActive(false);
        rightScreen.SetActive(false);
        StartCoroutine(ActivateScreensAfterTime(13.0f));

    }

    private IEnumerator ActivateScreensAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        creditsAnimator.ResetTrigger("PlayCredits");
        leftScreen.SetActive(true);
        midScreen.SetActive(true);
        rightScreen.SetActive(true);
    }
}
