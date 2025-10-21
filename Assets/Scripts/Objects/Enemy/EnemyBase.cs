using System;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected float _damage;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _maxHp;

    protected float _curHp;

    private void Start()
    {
        InitEnemy();
    }

    private void InitEnemy()
    {
        _curHp = _maxHp;
        GameManager.Instance.OnGameEndAction.AddListener(DestroySelf);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameEndAction.RemoveListener(DestroySelf);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        MoveDown();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if(player == null)
                return;

            player.OnTakeDamage(_damage);

            Destroy(gameObject);
            return;
        }

        if (other.CompareTag("EnemyChecker"))
        {
            Destroy(gameObject);
            return;
        }
    }

    private void MoveDown()
    {
        transform.Translate(Vector3.forward * -1 * _moveSpeed * Time.deltaTime);
    }
}
