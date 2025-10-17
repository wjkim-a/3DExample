using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    //�ش� ������Ʈ�� �̵��� �ӵ� ����
    [SerializeField] private float _moveSpeed;

    //���� ���� ��������Ʈ �� ��� ���ִ°�
    private int _currentTargetIndex = 0;
    //��������Ʈ�� ��Ƶ� �������� -> �ڽĵ��� ��������Ʈ�̴ϱ� �긦 ���� ��������Ʈ ���� ������ ����
    private Transform _wayPointBox;

    //�긦 ��ȯ���� �ܺ� Ŭ������ ȣ���� �� �ִ�, ��������Ʈ ���� �Լ�
    
    public void SetWayPointBox(Transform waypointBox)
    {
        _wayPointBox = waypointBox;
    }

    //�浹 üũ�� ���� ��������Ʈ �̵�
    private void OnTriggerEnter(Collider other)
    {
        //��������Ʈ�� �����Ѱ� �´��� Ȯ��
        if(other.CompareTag("WaypointChecker"))
        {
            //������ ���� ����ó��
            if (_wayPointBox == null)
                return;

            //Ÿ�� �̵�
            _currentTargetIndex += 1;

            //�ڽ��� ������ �ε��� ���� �������� �ʵ��� ó��
            if(_currentTargetIndex >= _wayPointBox.childCount)
                _currentTargetIndex = 0;
        }
    }

    private void Update()
    {
        MoveObj();
    }

    //��������Ʈ �̵� �Լ�
    private void MoveObj()
    {
        //�̵������� ���� ������ ���ٸ� �̵����� ����
        if (_wayPointBox == null)
            return;

        //���� ������ �ϴ� ������ ������ ��������
        Transform targetTrf = _wayPointBox.GetChild(_currentTargetIndex);

        //�� ������ �������� �̵��ؾ��� ������ �������
        Vector3 direction = (targetTrf.position - transform.position).normalized;

        //���� �������� �̵�����
        transform.position += direction * _moveSpeed * Time.deltaTime;
    }
}
