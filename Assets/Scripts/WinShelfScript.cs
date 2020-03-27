using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinShelfScript : MonoBehaviour
{
    //all
    private Animator animator;
    private int cartridgeCount = 0;
    private int totalCartridges = 4;

    private AudioSource winAudio;
    private AudioSource correctAudio;
    private AudioSource incorrectAudio;


    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        incorrectAudio = audioSources[0];
        correctAudio = audioSources[1];
        winAudio = audioSources[2];
    }

    public void AddCartridge(GameObject cartridge)
    {
        CartridgeJSONReader cartridgeScript = cartridge.GetComponent<CartridgeJSONReader>();
        if(cartridgeScript.GetCartridgeCompleteStatus() == true)
        {
            correctAudio.Play();
            cartridgeCount++;
            if (cartridgeCount == totalCartridges)
            {
                OpenShelf();
            }
        }
        else
        {
            incorrectAudio.Play();
        }
    }
    public void RemoveCartridge(GameObject cartridge)
    {
        CartridgeJSONReader cartridgeScript = cartridge.GetComponent<CartridgeJSONReader>();
        if (cartridgeScript.GetCartridgeCompleteStatus() == true)
        {
            cartridgeCount--;
        }
    }

    private void OpenShelf()
    {
        animator.SetTrigger("Open");
        winAudio.Play();
    }
    private void CloseShelf()
    {
        animator.ResetTrigger("Open");
    }
}
