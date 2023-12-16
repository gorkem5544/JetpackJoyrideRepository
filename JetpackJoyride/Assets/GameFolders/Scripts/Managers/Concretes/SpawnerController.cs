using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Concretes;
using UnityEngine;

public enum EnemySpawnType
{
    BarrierEnemySpawn, LaserEnemySpawn, Delay
}

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class SpawnerController : MonoBehaviour
    {
        IStateMachine _stateMachine;
        EnemySpawnType _enemySpawnType;
        BarrierSpawner _barrierSpawner;
        LaserSpawner _laserSpawner;

        public BarrierSpawner BarrierSpawner { get => _barrierSpawner; set => _barrierSpawner = value; }
        public LaserSpawner LaserSpawner { get => _laserSpawner; set => _laserSpawner = value; }

        private void Awake()
        {
            _barrierSpawner = GameObject.FindWithTag("BarrierSpawner").transform.GetComponent<BarrierSpawner>();
            _laserSpawner = GameObject.FindWithTag("LaserSpawner").transform.GetComponent<LaserSpawner>();

            _stateMachine = new StateMachine();
        }
        private void Start()
        {
            SpawnerControllerBarrierEnemySpawnState _spawnerControllerBarrierEnemySpawnState = new SpawnerControllerBarrierEnemySpawnState(this);
            SpawnerControllerLaserEnemySpawnState _spawnerControllerLaserEnemySpawnState = new SpawnerControllerLaserEnemySpawnState(this);
            SpawnerControllerDelayState _spawnerControllerDelayState = new SpawnerControllerDelayState(this);
            _stateMachine.SetState(_spawnerControllerBarrierEnemySpawnState);
            _stateMachine.SetNormalStateTransitions(_spawnerControllerBarrierEnemySpawnState, _spawnerControllerDelayState, () => _enemySpawnType == EnemySpawnType.Delay);
            _stateMachine.SetNormalStateTransitions(_spawnerControllerLaserEnemySpawnState, _spawnerControllerDelayState, () => _enemySpawnType == EnemySpawnType.Delay);

            _stateMachine.SetNormalStateTransitions(_spawnerControllerDelayState, _spawnerControllerBarrierEnemySpawnState, () => _enemySpawnType == EnemySpawnType.BarrierEnemySpawn);
            _stateMachine.SetNormalStateTransitions(_spawnerControllerDelayState, _spawnerControllerLaserEnemySpawnState, () => _enemySpawnType == EnemySpawnType.LaserEnemySpawn);

        }
        private void Update()
        {
            _stateMachine.UpdateTick();
        }
        public void EnemyManagerChangeState(EnemySpawnType enemySpawnType)
        {
            _enemySpawnType = enemySpawnType;
        }
    }

}
class SpawnerControllerBarrierEnemySpawnState : IState
{
    Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes.SpawnerController _enemyManager;
    float _currentSpawnTime = 0;
    public SpawnerControllerBarrierEnemySpawnState(Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes.SpawnerController enemyManager)
    {
        _enemyManager = enemyManager;
    }
    public void EnterState()
    {
        _enemyManager.BarrierSpawner.ResetSpawnTime();
        Debug.Log("Barrier Enter");
        _currentSpawnTime = 0;
    }

    public void ExitState()
    {
        Debug.Log("Barrier Exit");
        _enemyManager.BarrierSpawner.ResetSpawnTime();
        _currentSpawnTime = 0;
    }

    public void UpdateState()
    {
        _enemyManager.BarrierSpawner.SpawnerUpdateTick();
        _currentSpawnTime += Time.deltaTime;
        if (_currentSpawnTime > 10)
        {
            _enemyManager.EnemyManagerChangeState(EnemySpawnType.Delay);
        }
        Debug.Log("Barrier Update");

    }
}
public class SpawnerControllerLaserEnemySpawnState : IState
{
    Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes.SpawnerController _enemyManager;
    float _currentSpawnTime = 0;
    public SpawnerControllerLaserEnemySpawnState(Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes.SpawnerController enemyManager)
    {
        _enemyManager = enemyManager;

    }
    public void EnterState()
    {
        Debug.Log("Laser Enter");
        _enemyManager.LaserSpawner.Spawn();
        _currentSpawnTime = 0;
    }

    public void ExitState()
    {
        _currentSpawnTime = 0;
        Debug.Log("Laser Eixt");

    }

    public void UpdateState()
    {
        _currentSpawnTime += Time.deltaTime;
        if (_currentSpawnTime > 5)
        {
            _enemyManager.EnemyManagerChangeState(EnemySpawnType.Delay);
        }
        Debug.Log("Laser Update");

    }
    public bool IsLaserEnemySpawn()
    {
        return _currentSpawnTime > 5;
    }
}
public class SpawnerControllerDelayState : IState
{
    protected Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes.SpawnerController _enemyManager;
    float _currentSpawnTime = 0;
    float _timeBoundary;

    public SpawnerControllerDelayState(Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes.SpawnerController enemyManager)
    {
        _enemyManager = enemyManager;
    }
    public void EnterState()
    {
        Debug.Log("Delay Enter");
        _currentSpawnTime = 0;
        _timeBoundary = UnityEngine.Random.Range(3, 6);
    }

    public void ExitState()
    {
        Debug.Log("Delay Exit");
        _currentSpawnTime = 0;
    }

    public void UpdateState()
    {
        _currentSpawnTime += Time.deltaTime;
        if (_currentSpawnTime > _timeBoundary)
        {
            _enemyManager.EnemyManagerChangeState((enemySpawnType()));
        }
        Debug.Log("Delay Update");

    }
    EnemySpawnType enemySpawnType()
    {
        int _randomIndex = UnityEngine.Random.Range(0, 2);
        Debug.Log(_randomIndex);
        if (_randomIndex == 0)
        {
            return EnemySpawnType.BarrierEnemySpawn;
        }
        else
        {
            return EnemySpawnType.LaserEnemySpawn;
        }
    }

}
