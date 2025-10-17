using UnityEngine;

public class BulletBase : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            ITakeDamageAdapter adapter = other.GetComponent<ITakeDamageAdapter>();

            if (adapter == null)
                return;

            adapter.OnTakeDamage(_damage);

            Destroy(gameObject);
            return;
        }

        if(other.CompareTag("BulletChecker"))
        {
            Destroy(gameObject);
            return;
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
