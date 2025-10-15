using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] protected Transform _bulletBoxTrf;
    [SerializeField] protected BulletBase _bullet;

    private void Start()
    {
        if(_bulletBoxTrf == null)
            _bulletBoxTrf = transform;
    }

    public virtual void Fire()
    {
        GameObject bulletObj = Instantiate(_bullet.gameObject, transform);
        bulletObj.transform.parent = _bulletBoxTrf;
    }
}
