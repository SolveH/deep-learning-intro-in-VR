using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    //Example of how to execute action after 1s.
    /*public void QuitApplication()
    {
        StartCoroutine(QuitAfterSeconds(1.0f));
    }

    public IEnumerator QuitAfterSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        Application.Quit();
    }*/
}
