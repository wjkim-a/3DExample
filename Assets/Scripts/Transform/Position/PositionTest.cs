using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTest : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        MoveObj();
    }

    private void MoveObj()
    {
        transform.position += Vector3.forward * _moveSpeed * Time.deltaTime;
    }
}
