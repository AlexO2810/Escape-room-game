using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    [SerializeField] UnityEvent onCollected;
    public UnityEvent OnCollected => onCollected;
    [SerializeField] UnityEvent onStopDisplay;
    public UnityEvent OnStopDisplay => onStopDisplay;
    private void OnMouseDown()
    {
        Debug.Log("1");
        onCollected?.Invoke();
        Invoke("TimeOut",2);
    }
    private void TimeOut()
    {
        onStopDisplay?.Invoke();
    }
}
