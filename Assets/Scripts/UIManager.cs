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
        Application.OpenURL("https://forms.office.com/Pages/ResponsePage.aspx?id=cgahCS-CZ0SluluzdZZ8BWFeAtQp0AZFtMLY8Z3zzgxURTZGSDdBSTNMTlAwQ1BVUVdZVE5VV0U2TS4u");
    }

    public void PlaySubtitles()
    {
        credits.SetActive(true);
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
        credits.SetActive(false);
    }
}
