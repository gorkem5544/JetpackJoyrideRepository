using Concretes.Pools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSpawner : MonoBehaviour
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

            int spawnerIndex = Random.Range(0, _enemySpawnerPos.Length);
            Debug.Log("Spawn");
            LazerController lazerController = LazerPool.Instance.Get();
            lazerController.gameObject.SetActive(true);

            lazerController.transform.position = new Vector3(0, _enemySpawnerPos[spawnerIndex].transform.position.y);
            lazerController.transform.Rotate(new Vector3(0, 0, 90));
            ResetTime();
            //Instantiate(_lazerController, new Vector3(0, _enemySpawnerPos[spawnerIndex].transform.position.y), Quaternion.Euler(0, 0, 90));
        }






    }
    private void ResetTime()
    {
        _canSpawn = false;
        _currentSPawnTime = 0;
        _timeBaundary = Random.Range(_minSpawnTime, _maxSpawnTime);
    }
}
