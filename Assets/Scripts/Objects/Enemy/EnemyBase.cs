using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected float _maxHp;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _damage;
    protected float _curHp;

    private void OnEnable()
    {
        InitEnemy();
    }

    private void Update()
    {
        MoveDown();
    }
    private void OnTriggerEnter(Collider other)
    {
        ITakeDamageAdapter adapter = other.GetComponent<ITakeDamageAdapter>();

        if (adapter != null)
        {
            SendDamage(adapter);
            Destroy(gameObject);
            return;
        }

        if (other.CompareTag("EnemyChecker"))
        {
            Destroy(gameObject);
            return;
        }
    }

    protected virtual void SendDamage(ITakeDamageAdapter adapter)
    {
        adapter?.OnTakeDamage(_damage);
    }

    protected void InitEnemy()
    {
        _curHp = _maxHp;
    }

    private void MoveDown()
    {
        transform.Translate(Vector3.forward * -1 * _moveSpeed * Time.deltaTime);
    }

    protected virtual void OnTakeDamage(float damage)
    {
        _curHp -= damage;

        if (_curHp < 0)
        {
            _curHp = 0;
            Die();
        }
    }

    protected virtual void Die()
    {
        gameObject.SetActive(false);
    }
}
