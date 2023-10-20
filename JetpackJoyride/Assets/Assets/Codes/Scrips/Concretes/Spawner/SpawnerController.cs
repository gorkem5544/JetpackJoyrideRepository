using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] GameObject[] _barrier;
    [SerializeField] Transform[] _enemySpawnerPos;
    SelectNewEnemyType _newEnemy;
    private bool _canBarrier = true;
    [SerializeField] LazerController _lazerController;

    [SerializeField] float _maxSpawnTime;
    [SerializeField] float _minSpawnTime;

    float _currentSPawnTime;
    int[] layerIndex;
    float _timeBaundary;
    float _barrierTimeBaundary, barrierCurrentTime;

    private bool _canSpawn = false;
    private void Start()
    {
        _newEnemy = SelectNewEnemyType.Barrier;
        ResetTime();
    }

    private void ResetTime()
    {
        _currentSPawnTime = 0;
        _timeBaundary = Random.Range(_minSpawnTime, _maxSpawnTime);
    }

    private void Update()
    {

        switch (_newEnemy)
        {
            case SelectNewEnemyType.Barrier:

                _currentSPawnTime += Time.deltaTime;
                if (_currentSPawnTime > _timeBaundary)
                {
                    Spawn();
                    ResetTime();
                }
                barrierCurrentTime += Time.deltaTime;
                if (barrierCurrentTime > 10)
                {
                    _newEnemy = SelectNewEnemyType.Laser;
                    _canSpawn = true;
                }
                break;

            case SelectNewEnemyType.Laser:

                int spawnerIndex = Random.Range(0, _enemySpawnerPos.Length);
                for (int i = 0; i < 1; i++)
                {

                    break;
                }

                while (_canSpawn)
                {
                    Instantiate(_lazerController, new Vector3(0, _enemySpawnerPos[spawnerIndex].transform.position.y), Quaternion.Euler(0, 0, 90));
                    _canSpawn = false;
                    break;

                }


                barrierCurrentTime += Time.deltaTime;

                if (barrierCurrentTime > 20)
                {
                    barrierCurrentTime = 0;
                    _newEnemy = SelectNewEnemyType.Barrier;
                }
                break;

        }

    }

    private void Spawn()
    {
        // int layerIndex = Random.Range(0, _barrier.Length);
        int spawnerIndex = Random.Range(0, _enemySpawnerPos.Length);
        Debug.Log("Spawn");
        float randomRotate = Random.Range(0, 360);
        BarrierController barrierController = BarrierPool.Instance.Get();
        barrierController.gameObject.SetActive(true);
        barrierController.transform.position = _enemySpawnerPos[spawnerIndex].transform.position;
        barrierController.transform.Rotate(new Vector3(0, 0, randomRotate));

        //  Instantiate(_barrier[layerIndex], _enemySpawnerPos[spawnerIndex].transform.position, Quaternion.Euler(new Vector3(0, 0, randomRotate)));
    }
}
public enum SelectNewEnemyType
{
    Barrier, Laser
}