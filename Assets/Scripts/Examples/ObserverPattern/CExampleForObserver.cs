using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExampleForObserver : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _subject;

    private void Awake()
    {
        _subject?.AddObserver(this);
    }

    //���� ����� �ʱ�
    private void OnDestroy()
    {
        _subject?.RemoveObserver(this);
    }

    //�������̽����� ����� �Լ�
    public void OnNotify()
    {
        Debug.Log("�� �ް���� �ʾҾ�..");
    }
}
