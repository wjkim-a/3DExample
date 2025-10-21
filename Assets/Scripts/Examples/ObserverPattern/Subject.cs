using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    //���� ����� �� ������ ����Ʈ
    private List<IObserver> observers = new List<IObserver> ();

    //����, ���� ���
    public void AddObserver(IObserver Observer) => observers.Add (Observer);
    public void RemoveObserver(IObserver Observer) => observers.Remove (Observer);

    private void Start()
    {
        Notify();
    }

    private void Notify()
    {
        foreach(IObserver Observer in observers)
        {
            Observer.OnNotify ();
        }
    }
}
