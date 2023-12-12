using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawner : BaseSpawner
{

    protected override void EnemySpawnAction()
    {
        ResetSpawnTime();
        int spawnerIndex = Random.Range(0, _spawnTransforms.Length);
        float randomRotate = Random.Range(0, 360);
        BarrierController barrierController = BarrierPool.Instance.GetBarrierPool((BarrierTypeEnum)Random.Range(0, BarrierPool.Instance._barrierPrefabsArrayList.Length));
        barrierController.gameObject.SetActive(true);
        barrierController.transform.position = _spawnTransforms[spawnerIndex].transform.position;
        barrierController.transform.Rotate(new Vector3(0, 0, randomRotate));
    }
}
