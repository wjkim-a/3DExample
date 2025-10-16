using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveComponent))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHp;
    [SerializeField] private float _fireDelay;
    [SerializeField] private List<WeaponBase> _weapons;

    private float _fireCoolTime;
    private InputComponent _inputCompnent;

    private float _curHp;

    private void Start()
    {
        InitPlayer();
        SetComponent();
    }

    private void InitPlayer()
    {
        _curHp = _maxHp;
    }

    private void SetComponent()
    {
        _inputCompnent = GetComponent<InputComponent>();
        _inputCompnent.OnClickFireAction += Fire;
    }

    private void Fire()
    {
        if (_weapons == null)
            return;

        if (_fireCoolTime > 0)
        {
            _fireCoolTime -= Time.deltaTime;
            return;
        }

        foreach (WeaponBase weapon in _weapons)
            weapon.Fire();

        _fireCoolTime = _fireDelay;
    }

    public void OnTakeDamage(float damage)
    {
        _curHp -= damage;
        if (_curHp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        _inputCompnent.OnClickFireAction -= Fire;
    }
}
