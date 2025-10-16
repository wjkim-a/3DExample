using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    private float _horInput;
    private float _verInput;
    
    public Action OnClickFireAction;

    public float HorInput => _horInput;
    public float VerInput => _verInput;

    void Update()
    {
        _horInput = Input.GetAxisRaw("Horizontal");
        _verInput = Input.GetAxisRaw("Vertical");

        if(Input.GetAxisRaw("Fire1") > 0)
            OnClickFireAction?.Invoke();
    }
}