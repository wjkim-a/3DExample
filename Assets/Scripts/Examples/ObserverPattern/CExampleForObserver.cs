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

    //주의 까먹지 않기
    private void OnDestroy()
    {
        _subject?.RemoveObserver(this);
    }

    //인터페이스에서 약속한 함수
    public void OnNotify()
    {
        Debug.Log("난 받고싶지 않았어..");
    }
}
