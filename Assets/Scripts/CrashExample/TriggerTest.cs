using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("<color=#fe6857> 플레이어가 영역 내로 들어왔다</color>");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("<color=#fe6857> 플레이어가 영역 내에 존재한다</color>");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("<color=#fe6857> 플레이어가 영역에서 탈출했다</color>");
        }
    }
}
