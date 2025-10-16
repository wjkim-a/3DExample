using UnityEngine;

public class BulletBase : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BulletChecker"))
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
