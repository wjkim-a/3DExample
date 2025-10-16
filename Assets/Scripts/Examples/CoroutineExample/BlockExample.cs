using System.Collections;
using UnityEngine;

public class BlockExample : MonoBehaviour
{
    public enum ExecutionMode
    {
        Blocking = 0, 
        Coroutine = 1,
        Invoke = 2    
    }

    [Tooltip("���� ���")]
    [SerializeField] private ExecutionMode _exampleMode = ExecutionMode.Coroutine;

    [SerializeField] private int _loopCount = 100000;
    [SerializeField] private float _delayTime = 1.0f;

    private void BlockExpampleFunc()
    {
        Debug.Log("����: ���ŷ");

        int i = _loopCount;
        while (i > 0)
        {
            Debug.Log("��� ������");
            i--;
        }

        Debug.Log("����: ���ŷ");
    }

    private IEnumerator CoroutineExample()
    {
        Debug.Log("�ڷ�ƾ ����");

        for (int j = 0; j < _loopCount; j++)
        {
            Debug.Log("�ڷ�ƾ ������");
            yield return null;
        }

        Debug.Log("�ڷ�ƾ ����");
    }

    private void InvokeExample()
    {
        Debug.Log("Invoke ����");

        Invoke(nameof(FinishInvokeTask), _delayTime);

        Debug.Log($"Invoke ���� �Ϸ�: {_delayTime}�� �� 'Invoke ����' ��� ����");
    }

    private void FinishInvokeTask()
    {
        Debug.Log("Invoke ����: ����� �ð��� ������ �����");
    }

    void Start()
    {
        switch (_exampleMode)
        {
            case ExecutionMode.Blocking:
                BlockExpampleFunc();
                break;
            case ExecutionMode.Coroutine:
                StartCoroutine(CoroutineExample());
                break;
            case ExecutionMode.Invoke:
                InvokeExample();
                break;
            default:
                Debug.LogError("�� �� ���� ���� ���");
                break;
        }
    }
}