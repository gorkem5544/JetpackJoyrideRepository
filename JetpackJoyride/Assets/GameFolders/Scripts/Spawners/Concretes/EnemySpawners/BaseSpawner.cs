using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpawner : MonoBehaviour
{
    // [SerializeField] protected Transform[] _spawnTransforms;
    // [SerializeField] float _maxSpawnTime;
    // [SerializeField] float _minSpawnTime;
    // protected float _currentSpawnTime;
    // protected float _timeBoundary;
    // public void SpawnerUpdateTick()
    // {
    //     _currentSpawnTime += Time.deltaTime;
    //     if (_currentSpawnTime > _timeBoundary)
    //     {
    //         EnemySpawnAction();
    //     }
    // }

    // protected abstract void EnemySpawnAction();
    // public void ResetSpawnTime()
    // {
    //     _currentSpawnTime = 0;
    //     _timeBoundary = UnityEngine.Random.Range(_minSpawnTime, _maxSpawnTime);
    // }

}

