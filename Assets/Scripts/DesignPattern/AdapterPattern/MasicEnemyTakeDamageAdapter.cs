using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasicEnemyTakeDamageAdapter : MonoBehaviour, ITakeDamageAdapter
{
    [SerializeField] private float _weakness;

    //�Ƽ
    private MasicEnemy _enemy;

    //�뿪 ����
    private void Start()
    {
        _enemy = GetComponent<MasicEnemy>();

        if(_enemy == null)
            gameObject.SetActive(false);
    }

    //Ÿ��
    public void OnTakeDamage(float damage)
    {
        _enemy?.OnTakeMasicDamage(damage, _weakness);
    }
}
