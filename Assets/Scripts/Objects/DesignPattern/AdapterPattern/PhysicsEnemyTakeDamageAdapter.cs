using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEnemyTakeDamageAdapter : MonoBehaviour, ITakeDamageAdapter
{
    [SerializeField] private float _defense;

    //¾îµªÆ¼
    private PhysicsEnemy _enemy;


    //Åë¿ª ¿¬°á
    private void Start()
    {
        _enemy = GetComponent<PhysicsEnemy>();

        if(_enemy == null)
            gameObject.SetActive(false);
    }

    //Å¸°Ù
    public void OnTakeDamage(float damage)
    {
        _enemy?.OnTakePhysicsDamage(damage, _defense);
    }
}
