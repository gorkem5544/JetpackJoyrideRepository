using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.SpawnerScriptableObject;
using UnityEngine;

public class BarrierSpawner
{
    Transform[] _spawnTransforms;
    public BarrierSpawner(Transform[] spawnTransforms)
    {
        _spawnTransforms = spawnTransforms;
    }


    float _currentSpawnTime;
    float _timeBoundary;
    public void SpawnerUpdateTick()
    {
        _currentSpawnTime += Time.deltaTime;
        if (_currentSpawnTime > _timeBoundary)
        {
            EnemySpawnAction();
        }
    }

    private void EnemySpawnAction()
    {
        ResetSpawnTime();
        BarrierController barrierController = BarrierGenericPool.Instance.GetBarrierPool((BarrierTypeEnum)Random.Range(0, BarrierGenericPool.Instance._barrierPrefabsArrayList.Length));
        barrierController.transform.position = new Vector3(_spawnTransforms[0].transform.position.x + 5, _spawnTransforms[Random.Range(0, _spawnTransforms.Length)].transform.position.y);
        barrierController.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
        barrierController.gameObject.SetActive(true);
    }
    public void ResetSpawnTime()
    {
        _currentSpawnTime = 0;
        _timeBoundary = UnityEngine.Random.Range(0.5f, 1.5f);
    }
}
