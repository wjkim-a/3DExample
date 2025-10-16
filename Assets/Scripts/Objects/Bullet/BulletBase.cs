using UnityEngine;

public class BulletBase : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _damage;

    private void OnTriggerEnter(Collider other)
    {
        ITakeDamageAdapter adapter = other.GetComponent<ITakeDamageAdapter>();

        if(adapter != null )
        {
            adapter.OnTakeDamage(_damage);
        }

        if(other.CompareTag("BulletChecker") || other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        Vector3 moveVec = Vector3.forward * _moveSpeed * Time.deltaTime;
        transform.Translate(moveVec);
    }
}
