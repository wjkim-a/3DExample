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

    [Tooltip("실행 방식")]
    [SerializeField] private ExecutionMode _exampleMode = ExecutionMode.Coroutine;

    [SerializeField] private int _loopCount = 100000;
    [SerializeField] private float _delayTime = 1.0f;

    private void BlockExpampleFunc()
    {
        Debug.Log("시작: 블로킹");

        int i = _loopCount;
        while (i > 0)
        {
            Debug.Log("블록 진행중");
            i--;
        }

        Debug.Log("종료: 블로킹");
    }

    private IEnumerator CoroutineExample()
    {
        Debug.Log("코루틴 시작");

        for (int j = 0; j < _loopCount; j++)
        {
            Debug.Log("코루틴 진행중");
            yield return null;
        }

        Debug.Log("코루틴 종료");
    }

    private void InvokeExample()
    {
        Debug.Log("Invoke 시작");

        Invoke(nameof(FinishInvokeTask), _delayTime);

        Debug.Log($"Invoke 예약 완료: {_delayTime}초 후 'Invoke 종료' 출력 예정");
    }

    private void FinishInvokeTask()
    {
        Debug.Log("Invoke 종료: 예약된 시간이 지나서 실행됨");
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
                Debug.LogError("알 수 없는 실행 모드");
                break;
        }
    }
}