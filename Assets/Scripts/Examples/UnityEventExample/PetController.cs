using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _moveStopDistance;

    private Coroutine _moveCoroutine;

    private void Awake()
    {
        Init();
    }

    private void OnDestroy()
    {
        _player.OnPetCalled.RemoveListener(MoveToPlayer);
    }

    private void Init()
    {
        _player.OnPetCalled.AddListener(MoveToPlayer);
    }

    //�÷��̾��� ����Ƽ �̺�Ʈ�� �������� �ڷ�ƾ ���� �Լ�, �ڷ�ƾ�� �ߺ� ������� �ʵ��� ���� �߰���
    private void MoveToPlayer()
    {
        if(_moveCoroutine == null)
        {
            _moveCoroutine = StartCoroutine(MoveToTarget(_player.transform));
        }
    }

    //�÷��̾ ���� �̵��ϴµ� ������ ���ݱ��� �̵��ϸ� ���ߵ��� �ϴ� �ڷ�ƾ �Լ�
    private IEnumerator MoveToTarget(Transform target)
    {
        while (true)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);

            if (distance <= _moveStopDistance)
            {
                _moveCoroutine = null;
                yield break;
            }

            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                _moveSpeed * Time.deltaTime
                );

            yield return null;
        }
    }
}
