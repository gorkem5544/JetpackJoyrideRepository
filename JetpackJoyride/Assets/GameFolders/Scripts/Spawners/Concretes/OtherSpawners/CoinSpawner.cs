using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers;
using Assembly_CSharp.Assets.GameFolders.Scripts.Pools.Abstracts.OtherPools;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] Transform _coinParent;
    [SerializeField] Transform[] _singleCoinSpawnerTransforms;
    [SerializeField] Transform[] _multipleCoinSpawnerTransforms;
    int count;
    private void NormalCoinSpawn()
    {
        //_coinParent.transform.position = new Vector3(-10, _multipleCoinSpawnerTransforms[Random.Range(0, _multipleCoinSpawnerTransforms.Length)].transform.position.y);
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                CoinController newCoinController = CoinPool.Instance.Get();
                newCoinController.transform.position = _coinParent.transform.position + new Vector3(_coinParent.transform.position.x * j * 1.6f, _coinParent.transform.position.y * i * 0.9f);
                newCoinController.gameObject.SetActive(true);
            }
        }
    }

    public void SingleCoinSpawner()
    {
        for (int i = 0; i < _singleCoinSpawnerTransforms.Length; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                count++;
                CoinController newCoinController = CoinPool.Instance.Get();
                newCoinController.transform.position = _singleCoinSpawnerTransforms[i].transform.position + new Vector3(_singleCoinSpawnerTransforms[i].transform.position.x + (j) + (count * 2), _singleCoinSpawnerTransforms[i].transform.position.y * 0.9f);
                Debug.Log(_singleCoinSpawnerTransforms[i].transform.position.x + "|||" + _singleCoinSpawnerTransforms[i].transform.position.x * j * 1.6f);
                newCoinController.gameObject.SetActive(true);
            }
        }

    }

}
