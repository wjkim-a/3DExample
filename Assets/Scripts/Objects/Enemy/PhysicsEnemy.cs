using UnityEngine;
public class PhysicsEnemy : EnemyBase
{
    public void OnTakePhysicsDamage(float damage, float defense)
    {
        float defensedDamage = damage - defense;
        float resultDamage = defensedDamage < 0 ? 0 : defensedDamage;

        _curHp -= resultDamage;

        Debug.Log($"PhysicsEnemyHp = {_curHp}");

        if (_curHp <= 0)
        {
            _curHp = 0;
            Destroy(gameObject);
        }
    }
}
