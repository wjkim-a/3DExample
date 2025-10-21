using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveComponent))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _trfStartPos;
    [SerializeField] private float _maxHp;
    [SerializeField] private float _fireDelay;
    [SerializeField] private List<WeaponBase> _weapons;

    private float _curHp;
    private float _fireCoolTime;
    private InputComponent _inputCompnent;

    private List<IPlayerHpObserver> _hpObservers = new List<IPlayerHpObserver>();
    public void AddHPObserver(IPlayerHpObserver Observer) => _hpObservers.Add(Observer);
    public void RemoveHPObserver(IPlayerHpObserver Observer) => _hpObservers.Remove(Observer);

    private void Awake()
    {
        RegistPlayer();
    }

    private void Start()
    {
        InitPlayer();
        SetComponent();
    }

    private void RegistPlayer()
    {
        GameManager.Instance.OnGameStartAction += InitPlayer;
    }

    private void InitPlayer()
    {
        _curHp = _maxHp;
        transform.position = _trfStartPos.position;
        gameObject.SetActive(true);

        NotifyHpUpdate();
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

        foreach(WeaponBase weapon in _weapons) 
            weapon.Fire();

        _fireCoolTime = _fireDelay;
    }

    //공격 받을 경우 호출할 함수
    public void OnTakeDamage(float damage)
    {
        _curHp -= damage;

        Debug.Log($"playerHp = {_curHp}");

        NotifyHpUpdate();

        if (_curHp <= 0)
        {
            _curHp = 0;
            GameManager.Instance.ChangeGameState();
            gameObject.SetActive(false);
        }
    }

    private void NotifyHpUpdate()
    {
        foreach(IPlayerHpObserver observer in _hpObservers)
        {
            observer.OnPlayerHpChanged(_curHp, _maxHp);
        }
    }

    private void OnDestroy()
    {
        _inputCompnent.OnClickFireAction -= Fire;
    }
}