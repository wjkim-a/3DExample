using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    private bool _isPlaying = false;

    public bool IsPlaying { get { return _isPlaying; } }
    public event Action OnGameStartAction;
    [field: SerializeField] public UnityEvent OnGameEndAction { get; private set; } = new UnityEvent();


    //���� ������ ���������� ���θ� ��ȯ�ϴ� �Լ�
    public void ChangeGameState()
    {
        _isPlaying = !_isPlaying;

        if (_isPlaying)
            OnGameStartAction?.Invoke();
        else
            OnGameEndAction?.Invoke();
    }
}
