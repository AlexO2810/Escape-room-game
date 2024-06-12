using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drower : MonoBehaviour
{
    [SerializeField] private Animator animator;
     [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;
    [SerializeField] private AudioSource audioSource;
    public bool IsOpen => isOpen;
    private bool isOpen = false;
    
    private void OnMouseDown()
    {
        OpenClose();
    }
    public void OpenClose()
    {
        if(isOpen){
            isOpen = false;
            audioSource.PlayOneShot(closeSound);
        }
        else{
            isOpen = true;
            audioSource.PlayOneShot(openSound);
        }
        animator.SetBool("IsOpen", isOpen);
    }

}
