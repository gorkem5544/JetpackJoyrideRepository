using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawner : MonoBehaviour
{
    [SerializeField] Transform[] _spawnTransforms;


    [SerializeField] BarrierSpawner _barrierSpawner;
    [SerializeField] LazerSpawner _lazerSpawner;
    SelectNewEnemyType _enemyType;

    [SerializeField] float _delay;
    float _currentDelayTime;

    private void Start()
    {
        _enemyType = SelectNewEnemyType.Barrier;
    }
    private void Update()
    {

        _currentDelayTime += Time.deltaTime;


        switch (_enemyType)
        {
            case SelectNewEnemyType.Barrier:
                _barrierSpawner.Spawn();
                if (_currentDelayTime > _delay)
                {
                    _enemyType = SelectNewEnemyType.Laser;
                    _currentDelayTime = 0;
                }
                break;
            case SelectNewEnemyType.Laser:
                for (int i = 0; i < 3; i++)
                {
                    _lazerSpawner.Spawn();

                }
                if (_currentDelayTime > _delay)
                {
                    _currentDelayTime = 0;

                    _enemyType = SelectNewEnemyType.Barrier;
                }
                break;
        }
    }

}

