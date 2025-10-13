using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("게임 시작했어");
    }

    void Update()
    {
        //Debug.Log("업데이트 중이야아아아아아");
    }

    private void OnDisable()
    {
        Debug.Log("나 비활성화 됐어");
    }
}
