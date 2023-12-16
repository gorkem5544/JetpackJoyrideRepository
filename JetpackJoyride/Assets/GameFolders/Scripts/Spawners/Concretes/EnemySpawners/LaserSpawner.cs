using Concretes.Pools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{

    [SerializeField] protected Transform[] _spawnTransforms;
    public void Spawn()
    {
        int spawnerIndex = Random.Range(0, _spawnTransforms.Length);
        LazerController lazerController = LazerPool.Instance.Get();
        lazerController.gameObject.SetActive(true);
        lazerController.transform.position = new Vector3(0, _spawnTransforms[spawnerIndex].transform.position.y);

    }
}
