using UnityEngine;
public class MasicEnemy : EnemyBase
{
    public void OnTakeMasicDamage(float damage, float weakness)
    {
        float resultDamage = damage + weakness;

        _curHp -= resultDamage;

        Debug.Log($"MasicEnemyHp = {_curHp}");

        if(_curHp <= 0)
        {
            _curHp = 0;
            Destroy(gameObject);
        }
    }
}
