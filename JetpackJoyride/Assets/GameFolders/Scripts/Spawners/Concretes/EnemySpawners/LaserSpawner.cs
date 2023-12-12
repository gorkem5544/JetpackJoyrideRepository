using Concretes.Pools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : BaseSpawner
{

    protected override void EnemySpawnAction()
    {
        ResetSpawnTime();
    }
    public void Spawn()
    {
        int spawnerIndex = Random.Range(0, _spawnTransforms.Length);
        LazerController lazerController = LazerPool.Instance.Get();
        lazerController.gameObject.SetActive(true);
        //lazerController.transform.Rotate(new Vector3(0, 0, 90));

        lazerController.transform.position = new Vector3(0, _spawnTransforms[spawnerIndex].transform.position.y);

    }
}
