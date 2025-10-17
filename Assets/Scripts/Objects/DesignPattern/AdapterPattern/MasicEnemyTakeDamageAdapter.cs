using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasicEnemyTakeDamageAdapter : MonoBehaviour, ITakeDamageAdapter
{
    [SerializeField] private float _weakness;

    //¾îµªÆ¼
    private MasicEnemy _enemy;

    //Åë¿ª ¿¬°á
    private void Start()
    {
        _enemy = GetComponent<MasicEnemy>();

        if(_enemy == null)
            gameObject.SetActive(false);
    }

    //Å¸°Ù
    public void OnTakeDamage(float damage)
    {
        _enemy?.OnTakeMasicDamage(damage, _weakness);
    }
}
