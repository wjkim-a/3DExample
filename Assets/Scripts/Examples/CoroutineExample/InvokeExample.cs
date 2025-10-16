using UnityEngine;

public class InvokeExample : MonoBehaviour
{
    void Start()
    {
        // 2초 뒤에 Hello 메서드 실행
        Invoke("Hello", 2f);

        // 1초 뒤부터 3초 간격으로 RepeatHello 실행
        InvokeRepeating("RepeatHello", 1f, 3f);
    }

    void Hello()
    {
        Debug.Log("Hello after 2 seconds!");
    }

    void RepeatHello()
    {
        Debug.Log("Repeating every 3 seconds!");
    }

    void StopRepeating()
    {
        // 반복 호출 멈춤
        CancelInvoke("RepeatHello");
    }
}
