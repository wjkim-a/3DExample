using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyObj : MonoBehaviour
{
    [SerializeField] private float _destroyDelay;
    private float _aliveTime = 0f;

    void Update()
    {
        CheckSelfDestroy();
    }

    private void CheckSelfDestroy()
    {
        if (_aliveTime >= _destroyDelay)
            Destroy(gameObject);
    }
}
