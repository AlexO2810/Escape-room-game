using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndGame : MonoBehaviour
{
    [SerializeField] private UnityEvent onClicked;
    public UnityEvent OnClicked => onClicked;
    public void OnMouseDown()
    {
        onClicked?.Invoke();
    }
}
