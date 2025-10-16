using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private int _currentTargetIndex = 0;
    private Transform _waypointBox;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("WaypointChecker"))
        {
            if (_waypointBox == null)
                return;

            _currentTargetIndex += 1;

            if( _currentTargetIndex >= _waypointBox.childCount)
                _currentTargetIndex = 0;
        }
    }

    private void Update()
    {
        MoveObj();
    }

    public void SetWaypointBox(Transform waypointBox)
    {
        _waypointBox = waypointBox;
    }

    private void MoveObj()
    {
        if (_waypointBox == null)
            return;

        Transform targetTrf = _waypointBox.GetChild(_currentTargetIndex);
        Vector3 direction = targetTrf.position - transform.position;
        transform.position += direction * _moveSpeed * Time.deltaTime;
    }
}
