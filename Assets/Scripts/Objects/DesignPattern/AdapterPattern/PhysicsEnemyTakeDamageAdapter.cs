using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEnemyTakeDamageAdapter : MonoBehaviour, ITakeDamageAdapter
{
    [SerializeField] private float _defense;

    //�Ƽ
    private PhysicsEnemy _enemy;


    //�뿪 ����
    private void Start()
    {
        _enemy = GetComponent<PhysicsEnemy>();

        if(_enemy == null)
            gameObject.SetActive(false);
    }

    //Ÿ��
    public void OnTakeDamage(float damage)
    {
        _enemy?.OnTakePhysicsDamage(damage, _defense);
    }
}
