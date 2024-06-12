using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Book : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private UnityEvent onBookClicked;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip bookSound;
    public bool IsClicked => isClicked;
    public UnityEvent OnBookClicked => onBookClicked;
    private bool isClicked = false;
    
    private void OnMouseDown()
    {
        OpenClose();
    }
    public void OpenClose()
    {
        if(!isClicked){
            isClicked = true;
            animator.SetBool("IsClicked", isClicked);
            audioSource.PlayOneShot(bookSound);
            Invoke("eventStart",1);
            
        }
        
    }
    private void eventStart()
    {
        onBookClicked?.Invoke();
    }
}
