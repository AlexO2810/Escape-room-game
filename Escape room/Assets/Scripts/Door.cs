using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;
    [SerializeField] private AudioSource audioSource;
    public bool IsOpen => isOpen;
    private bool isOpen = false;
    private bool open = false;

    public void Open()
    {
        open = true;
    }
    private void OnMouseDown()
    {
        OpenClose();
    }
    public void OpenClose()
    {
        if(open)
        {
            if(isOpen)
            {
                audioSource.PlayOneShot(closeSound);
            }
            else
            {
                audioSource.PlayOneShot(openSound);
            }
            isOpen = !isOpen;
            animator.SetBool("IsOpen", isOpen);
        }
    }
}
