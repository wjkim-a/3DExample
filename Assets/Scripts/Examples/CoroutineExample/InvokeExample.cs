using UnityEngine;

public class InvokeExample : MonoBehaviour
{
    void Start()
    {
        // 2�� �ڿ� Hello �޼��� ����
        Invoke("Hello", 2f);

        // 1�� �ں��� 3�� �������� RepeatHello ����
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
        // �ݺ� ȣ�� ����
        CancelInvoke("RepeatHello");
    }
}
