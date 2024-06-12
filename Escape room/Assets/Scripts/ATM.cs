using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATM : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public bool Move => move;
    private bool move = false;
    
    public void Moving()
    {
        move = true;
        
        animator.SetBool("Move", move);
    }
}
