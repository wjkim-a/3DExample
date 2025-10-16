using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateTest : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        MoveObj();
    }

    private void MoveObj()
    {
        transform.Translate(Vector3.up *  _moveSpeed *  Time.deltaTime);
    }
}
