using UnityEngine;

public class MasicEnemyTakeDamageAdapter : MonoBehaviour, ITakeDamageAdapter
{
    [SerializeField] private float _weakness;

    private MasicEnemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<MasicEnemy>();

        if (_enemy == null)
            gameObject.SetActive(false);
    }

    public void OnTakeDamage(float damage)
    {
        _enemy?.OnTakeMasicDamage(damage, _weakness);
    }
}
