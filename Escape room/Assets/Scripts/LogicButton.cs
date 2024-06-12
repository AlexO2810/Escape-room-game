using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LogicButton : MonoBehaviour
{
    [SerializeField] private UnityEvent onClicked;
    public UnityEvent OnClicked => onClicked;
    [SerializeField] private UnityEvent onReliesed;
    public UnityEvent OnReliesed => onReliesed;
    private bool IsClicked = false;
    public void OnMouseDown()
    {
        if(IsClicked)
        {
            onReliesed?.Invoke();
            IsClicked = !IsClicked;
        }
        else
        {
            onClicked?.Invoke();
            IsClicked = !IsClicked;
        }
    }
}
