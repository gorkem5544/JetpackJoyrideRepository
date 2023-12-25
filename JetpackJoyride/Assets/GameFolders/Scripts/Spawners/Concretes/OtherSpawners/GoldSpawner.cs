using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Pools.Abstracts.OtherPools;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    Transform[] _spawnTransforms;
    public GoldSpawner(Transform[] spawnTransforms)
    {
        _spawnTransforms = spawnTransforms;
    }
    int count;

    public void OneCoinSpawn()
    {
        GoldController newCoinController = GoldPool.Instance.Get();
        newCoinController.transform.position = _spawnTransforms[Random.Range(0, _spawnTransforms.Length)].transform.position;
        newCoinController.gameObject.SetActive(true);
    }

    public void SingleCoinSpawner()
    {
        for (int i = 0; i < _spawnTransforms.Length; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                count++;
                GoldController newCoinController = GoldPool.Instance.Get();
                newCoinController.transform.position = _spawnTransforms[i].transform.position + new Vector3(_spawnTransforms[i].transform.position.x + (j) + (count * 2), _spawnTransforms[i].transform.position.y * 0.9f);
                newCoinController.gameObject.SetActive(true);
            }
        }

    }

}
