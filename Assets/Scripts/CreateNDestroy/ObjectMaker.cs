using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMaker : MonoBehaviour
{
    [SerializeField] private int _makeObjCount;
    [SerializeField] private GameObject _obj;
    [SerializeField] private Transform _objParents;    

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
            MakeObj();
    }

    private void MakeObj()
    {
        if (_obj == null)
            return;

        for (int i = 0; i < _makeObjCount; i++)
        {
            GameObject obj = Instantiate(_obj, _objParents);
            obj.transform.position = new Vector3(Random.Range(0, 20), 0, Random.Range(0, 20));
        }
    }
}
