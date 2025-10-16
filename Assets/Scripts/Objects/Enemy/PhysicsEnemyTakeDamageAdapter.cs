using UnityEngine;

public class PhysicsEnemyTakeDamageAdapter : MonoBehaviour, ITakeDamageAdapter
{
    [SerializeField] private float _defense;

    private PhysicsEnemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<PhysicsEnemy>();

        if (_enemy == null)
            gameObject.SetActive(false);
    }

    public void OnTakeDamage(float damage)
    {
        _enemy?.OnTakePhysicsDamage(damage, _defense);
    }
}
