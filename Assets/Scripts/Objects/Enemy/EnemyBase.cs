using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed;

    private void Update()
    {
        MoveDown();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyChecker") || other.CompareTag("Player"))
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
