using System.Collections;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    void Start()
    {
        // 코루틴 실행
        StartCoroutine(PrintNumbers());
    }

    IEnumerator PrintNumbers()
    {
        for (int i = 1; i <= 5; i++)
        {
            Debug.Log(i);
            yield return new WaitForSeconds(1f); // 1초 대기
        }
    }
}
