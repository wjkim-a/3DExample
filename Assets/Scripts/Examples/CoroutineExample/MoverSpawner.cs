using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _moverPrefab;
    [SerializeField] private Transform _waypointBox;
    [SerializeField] private float _spawnDelay;

    private WaitForSeconds _delay;

    private void Start()
    {
        _delay = new WaitForSeconds(_spawnDelay);
        StartCoroutine(SpawnMover());
    }

    private IEnumerator SpawnMover()
    {
        while (true)
        {
            GameObject newMoverObj = Instantiate(_moverPrefab, transform);
            WaypointMover newMover = newMoverObj.GetComponent<WaypointMover>();
            newMover.SetWaypointBox(_waypointBox);

            yield return _delay;
        }
    }
}
