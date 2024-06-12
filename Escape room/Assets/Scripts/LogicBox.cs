using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LogicBox : MonoBehaviour
{
    [SerializeField] private bool A;
    [SerializeField] private bool B;
    [SerializeField] private bool C;
    [SerializeField] private UnityEvent onAccessGranted;
    [SerializeField] private UnityEvent onAccessDenied;

    private bool a = false;
    private bool b = false;
    private bool c = false;
    public UnityEvent OnAccessGranted => onAccessGranted;
    public UnityEvent OnAccessDenied => onAccessDenied;

    public void ChangeA()
    {
        a = !a;
        Check();
    }
    public void ChangeB()
    {
        b = !b;
        Check();
    }
    public void ChangeC()
    {
        c = !c;
        Check();
    }

    private void Check()
    {
        if(A == a && B == b && C == c)
        {
            onAccessGranted?.Invoke();
        }
        else
        {
            onAccessDenied?.Invoke(); 
        }
    }

}
