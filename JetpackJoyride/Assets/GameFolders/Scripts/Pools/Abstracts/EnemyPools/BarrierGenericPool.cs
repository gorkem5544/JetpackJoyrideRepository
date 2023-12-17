
using System;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Combats.Concretes.PlayerCombats;
using UnityEngine;

public abstract class BarrierGenericPool : SingletonDontDestroyMonoObject<BarrierGenericPool>, IResetPool
{

    [SerializeField] public BarrierController[] _barrierPrefabsArrayList;
    [SerializeField] int _countLoop;
    Dictionary<BarrierTypeEnum, Queue<BarrierController>> _barriersDictionaryList = new Dictionary<BarrierTypeEnum, Queue<BarrierController>>();

    private PlayerHealth _playerHealth;
    private void Start()
    {
        _playerHealth = PlayerManager.Instance.PlayerController.PlayerHealth;
        GrowPool();
        _playerHealth.OnDead += ResetAllObject;
        _playerHealth.OnReSpawn += ResetAllObject;
    }
    private void OnDisable()
    {
        _playerHealth.OnDead -= ResetAllObject;
        _playerHealth.OnReSpawn -= ResetAllObject;
    }
    public BarrierController GetBarrierPool(BarrierTypeEnum barrierTypeEnum)
    {

        Queue<BarrierController> _blockQueueList = _barriersDictionaryList[barrierTypeEnum];
        if (_blockQueueList.Count == 0)
        {
            for (int i = 0; i < 2; i++)
            {
                BarrierController _newBarrierController = Instantiate(_barrierPrefabsArrayList[(int)barrierTypeEnum]);
                _newBarrierController.transform.parent = this.transform;
                _blockQueueList.Enqueue(_newBarrierController);
            }
        }
        return _blockQueueList.Dequeue();
    }
    public void GrowPool()
    {
        for (int i = 0; i < _barrierPrefabsArrayList.Length; i++)
        {
            Queue<BarrierController> _barrierQueueList = new Queue<BarrierController>();
            for (int j = 0; j < _countLoop; j++)
            {
                BarrierController _newBarrierController = Instantiate(_barrierPrefabsArrayList[i]);
                _newBarrierController.transform.parent = this.transform;
                _newBarrierController.gameObject.SetActive(false);
                _barrierQueueList.Enqueue(_newBarrierController);

            }
            _barriersDictionaryList.Add((BarrierTypeEnum)i, _barrierQueueList);
        }

    }

    public void SetPool(BarrierController BarrierController)
    {
        BarrierController.gameObject.SetActive(false);
        BarrierController.transform.parent = this.transform;
        Queue<BarrierController> _blockQueueList = _barriersDictionaryList[BarrierController.BarrierTypeEnum];
        _blockQueueList.Enqueue(BarrierController);
    }
    // protected abstract void KillAllObjet();

    public abstract void ResetAllObject();

}