using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("<color=#fe6857> �÷��̾ ���� ���� ���Դ�</color>");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("<color=#fe6857> �÷��̾ ���� ���� �����Ѵ�</color>");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("<color=#fe6857> �÷��̾ �������� Ż���ߴ�</color>");
        }
    }
}
