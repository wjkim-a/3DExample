using System.Collections;
using UnityEngine;

public enum eEnemyType
{
    Physics,
    Masic
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private PhysicsEnemy _physicsEnemyPrefab;
    [SerializeField] private MasicEnemy _masicEnemyPrefab;
    [SerializeField] private float _spawnDelay = 1f;
    [SerializeField] private Transform _trfSpawonPosLeft;
    [SerializeField] private Transform _trfSpawonPosRight;

    private Coroutine _spawnEnemyCorutine;

    private void Start()
    {
        StartGameAction();
    }

    private void StartGameAction()
    {
        StartSpawnEnemy();
    }

    private void StartSpawnEnemy()
    {
        if(_spawnEnemyCorutine != null) 
            _spawnEnemyCorutine = null;

        _spawnEnemyCorutine = StartCoroutine(CreateEnemyProcess());
    }

    private IEnumerator CreateEnemyProcess()
    {
        while(true)
        {
            yield return new WaitForSeconds(_spawnDelay);

            int rand = Random.Range(0, 2);
            CreateEnemy((eEnemyType)rand);
        }
    }

    private void CreateEnemy(eEnemyType type)
    {
        EnemyBase enemy = null;

        switch (type) 
        {
            case eEnemyType.Physics:
                enemy = _physicsEnemyPrefab;
                break;
            case eEnemyType.Masic:
                enemy = _masicEnemyPrefab;
                break;
            default:
                break;
        }

        if (enemy == null)
            return;

        GameObject enemyObj = Instantiate(enemy.gameObject, transform);
        EnemyBase newEnemy = enemyObj.GetComponent<EnemyBase>();
        SetSpawonPos(newEnemy.gameObject);
    }

    private void SetSpawonPos(GameObject obj)
    {
        float randXPos = Random.Range(_trfSpawonPosLeft.position.x, _trfSpawonPosRight.position.x);
        obj.transform.position = new Vector3(randXPos, obj.transform.position.y, obj.transform.position.z);
    }
}
