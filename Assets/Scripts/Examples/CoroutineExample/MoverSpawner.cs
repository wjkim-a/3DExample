using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverSpawner : MonoBehaviour
{
    //��ȯ�� ��� ������
    [SerializeField] private GameObject _moverPrefab;
    //��ȯ ��󿡰� ������ ��������Ʈ ����
    [SerializeField] private Transform _waypointBox;
    //��ȯ ����
    [SerializeField] private float _spawnDelay;

    private WaitForSeconds _delay;

    private void Start()
    {
        _delay = new WaitForSeconds(_spawnDelay);
        StartCoroutine(SpawnMover());
    }

    //��ȯ�� ����� �ڷ�ƾ �Լ�
    private IEnumerator SpawnMover()
    {
        //������ ���� ����ó��
        if(_waypointBox == null)
            yield break;

        //��� ��ȯ�ϱ� ���� �ݺ���
        while (true)
        {
            //���ο� ��ü ����
            GameObject newMoverObj = Instantiate(_moverPrefab, transform);
            //������ ��ü���� �츮�� ���� ��������Ʈ �̵� ������Ʈ�� ������ ������
            WaypointMover newMover = newMoverObj.GetComponent<WaypointMover>();
            //�̵��� ��ġ�鿡 ���� ������ ��������
            newMover?.SetWayPointBox(_waypointBox);

            //������ �ð� �������� �����ϵ��� ����
            yield return _delay;
        }
    }
}
