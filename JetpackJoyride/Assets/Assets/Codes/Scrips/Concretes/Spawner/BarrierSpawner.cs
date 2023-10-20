using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawner : MonoBehaviour
{
    [SerializeField] Transform[] _enemySpawnerPos;
    [SerializeField] float _maxSpawnTime;
    [SerializeField] float _minSpawnTime;

    float _currentSPawnTime;

    int[] layerIndex;
    float _timeBaundary;
    float _barrierTimeBaundary, barrierCurrentTime;


    private bool _canSpawn = false;
    private void Update()
    {
        _currentSPawnTime += Time.deltaTime;
        if (_currentSPawnTime > _timeBaundary)
        {
            _canSpawn = true;
        }
    }

    public void Spawn()
    {
        if (_canSpawn)
        {
            // int layerIndex = Random.Range(0, _barrier.Length);
            int spawnerIndex = Random.Range(0, _enemySpawnerPos.Length);
            Debug.Log("Spawn");
            float randomRotate = Random.Range(0, 360);
            BarrierController barrierController = BarrierPool.Instance.Get();
            barrierController.gameObject.SetActive(true);
            barrierController.transform.position = _enemySpawnerPos[spawnerIndex].transform.position;
            barrierController.transform.Rotate(new Vector3(0, 0, randomRotate));
            ResetTime();

        }


    }
    private void ResetTime()
    {
        _canSpawn = false;
        _currentSPawnTime = 0;
        _timeBaundary = Random.Range(_minSpawnTime, _maxSpawnTime);
    }
}
