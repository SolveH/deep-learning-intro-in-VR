using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour
{
    private Animator animator;
    private AudioSource doorSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        doorSound = GetComponentInParent<AudioSource>();
    }

    public void OpenDoor()
    {
        animator.SetTrigger("TaskSolved");
        doorSound.Play();
    }

    public void CloseDoor()
    {
        animator.ResetTrigger("TaskSolved");
        doorSound.Play();
    }
}
