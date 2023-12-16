using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.SpawnerScriptableObject;
using UnityEngine;

public class BarrierSpawner : MonoBehaviour
{
    [SerializeField] BarrierSpawnerSO _barrierSpawnerSo;

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
        //int spawnerIndex = Random.Range(0, _barrierSpawnerSo.SpawnTransforms.Length);
        //float randomRotate = Random.Range(0, 360);
        BarrierController barrierController = BarrierPool.Instance.GetBarrierPool((BarrierTypeEnum)Random.Range(0, BarrierPool.Instance._barrierPrefabsArrayList.Length));
        barrierController.gameObject.SetActive(true);
        barrierController.transform.position = new Vector3(30, _barrierSpawnerSo.SpawnTransforms[Random.Range(0, _barrierSpawnerSo.SpawnTransforms.Length)].transform.position.y);
        barrierController.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
    }
    public void ResetSpawnTime()
    {
        _currentSpawnTime = 0;
        _timeBoundary = UnityEngine.Random.Range(_barrierSpawnerSo.MinSpawnTime, _barrierSpawnerSo.MaxSpawnTime);
    }
}
