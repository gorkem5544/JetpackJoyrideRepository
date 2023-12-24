using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Concretes;
using UnityEngine;

public enum SpawningObjectTypeEnum
{
    BarrierEnemySpawn, LaserEnemySpawn, Delay, Gold, NotSpawn, Rocket
}

public interface ISpawnerControllerRocketSpawnService
{
    RocketSpawner RocketSpawner { get; }
    IStateMachine StateMachine { get; }

}
public interface ISpawnerController
{
    IStateMachine StateMachine { get; }
    BarrierSpawner BarrierSpawner { get; }
    LaserSpawner LaserSpawner { get; }
    GoldSpawner GoldSpawner { get; }
    RocketSpawner RocketSpawner { get; }
}
namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class SpawnerController : MonoBehaviour, ISpawnerController, ISpawnerControllerRocketSpawnService
    {
        IStateMachine _stateMachine;
        SpawningObjectTypeEnum _spawningObjectTypeEnum;
        BarrierSpawner _barrierSpawner;
        LaserSpawner _laserSpawner;
        GoldSpawner _goldSpawner;
        [SerializeField] RocketSpawner _rocketSpawner;

        public BarrierSpawner BarrierSpawner { get => _barrierSpawner; set => _barrierSpawner = value; }
        public LaserSpawner LaserSpawner { get => _laserSpawner; set => _laserSpawner = value; }
        public GoldSpawner GoldSpawner { get => _goldSpawner; set => _goldSpawner = value; }
        public IStateMachine StateMachine => _stateMachine;
        public RocketSpawner RocketSpawner => _rocketSpawner;



        private void Awake()
        {
            _barrierSpawner = GameObject.FindWithTag("BarrierSpawner").transform.GetComponent<BarrierSpawner>();
            _laserSpawner = GameObject.FindWithTag("LaserSpawner").transform.GetComponent<LaserSpawner>();
            _goldSpawner = GameObject.FindWithTag("GoldSpawner").transform.GetComponent<GoldSpawner>();
            _stateMachine = new StateMachine();
        }
        private void Start()
        {
            SpawnerControllerBarrierEnemySpawnState _spawnerControllerBarrierEnemySpawnState = new SpawnerControllerBarrierEnemySpawnState(this);
            SpawnerControllerLaserEnemySpawnState _spawnerControllerLaserEnemySpawnState = new SpawnerControllerLaserEnemySpawnState(this);
            SpawnerControllerDelayState _spawnerControllerDelayState = new SpawnerControllerDelayState(this);
            SpawnerControllerGoldSpawnState _spawnerControllerGoldSpawnState = new SpawnerControllerGoldSpawnState(this);
            SpawnerControllerNotSpawnState _spawnerControllerNotSpawnState = new SpawnerControllerNotSpawnState(this);
            SpawnerControllerRocketSpawnState _spawnerControllerRocketSpawnState = new SpawnerControllerRocketSpawnState(this);

            _stateMachine.SetState(_spawnerControllerDelayState);

            _stateMachine.SetNormalStateTransitions(_spawnerControllerDelayState, _spawnerControllerBarrierEnemySpawnState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.BarrierEnemySpawn);
            _stateMachine.SetNormalStateTransitions(_spawnerControllerBarrierEnemySpawnState, _spawnerControllerDelayState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.Delay);

            _stateMachine.SetNormalStateTransitions(_spawnerControllerDelayState, _spawnerControllerLaserEnemySpawnState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.LaserEnemySpawn);
            _stateMachine.SetNormalStateTransitions(_spawnerControllerLaserEnemySpawnState, _spawnerControllerDelayState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.Delay);

            _stateMachine.SetNormalStateTransitions(_spawnerControllerDelayState, _spawnerControllerGoldSpawnState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.Gold);
            _stateMachine.SetNormalStateTransitions(_spawnerControllerGoldSpawnState, _spawnerControllerDelayState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.Delay);

            _stateMachine.SetAnyStateTransitions(_spawnerControllerNotSpawnState, () => GameManager.Instance.GameManagerState == GameManagerState.GameOverState);
            _stateMachine.SetNormalStateTransitions(_spawnerControllerNotSpawnState, _spawnerControllerDelayState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.Delay);

            _stateMachine.SetNormalStateTransitions(_spawnerControllerDelayState, _spawnerControllerRocketSpawnState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.Rocket);
            _stateMachine.SetNormalStateTransitions(_spawnerControllerRocketSpawnState, _spawnerControllerDelayState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.Delay);


        }
        private void Update()
        {
            _stateMachine.UpdateTick();

        }
        public void SpawnerControllerChangeState(SpawningObjectTypeEnum enemySpawnType) => _spawningObjectTypeEnum = enemySpawnType;

    }

}
class SpawnerControllerBarrierEnemySpawnState : IState
{
    SpawnerController _enemyManager;
    float _currentSpawnTime = 0;
    public SpawnerControllerBarrierEnemySpawnState(SpawnerController enemyManager)
    {
        _enemyManager = enemyManager;
    }
    public void EnterState()
    {
        _enemyManager.BarrierSpawner.ResetSpawnTime();

        _currentSpawnTime = 0;
    }

    public void ExitState()
    {

        _enemyManager.BarrierSpawner.ResetSpawnTime();
        _currentSpawnTime = 0;
    }

    public void UpdateState()
    {
        _enemyManager.BarrierSpawner.SpawnerUpdateTick();
        _currentSpawnTime += Time.deltaTime;
        if (_currentSpawnTime > 10)
        {
            _enemyManager.SpawnerControllerChangeState(SpawningObjectTypeEnum.Delay);
        }
        Debug.Log("Barrier Update");

    }
}
public class SpawnerControllerLaserEnemySpawnState : IState
{
    SpawnerController _enemyManager;
    float _currentSpawnTime = 0;
    public SpawnerControllerLaserEnemySpawnState(SpawnerController enemyManager)
    {
        _enemyManager = enemyManager;

    }
    public void EnterState()
    {

        _enemyManager.LaserSpawner.Spawn();
        _currentSpawnTime = 0;
    }

    public void ExitState()
    {
        _currentSpawnTime = 0;


    }

    public void UpdateState()
    {
        _currentSpawnTime += Time.deltaTime;
        if (_currentSpawnTime > 5)
        {
            _enemyManager.SpawnerControllerChangeState(SpawningObjectTypeEnum.Delay);
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
    protected SpawnerController _enemyManager;
    float _currentSpawnTime = 0;
    float _timeBoundary;

    public SpawnerControllerDelayState(SpawnerController enemyManager)
    {
        _enemyManager = enemyManager;
    }
    public void EnterState()
    {

        _currentSpawnTime = 0;
        _timeBoundary = UnityEngine.Random.Range(3, 6);
    }

    public void ExitState()
    {

        _currentSpawnTime = 0;
    }

    public void UpdateState()
    {
        _currentSpawnTime += Time.deltaTime;
        if (_currentSpawnTime > _timeBoundary)
        {
            _enemyManager.SpawnerControllerChangeState((enemySpawnType()));
        }
        Debug.Log("Delay Update");

    }
    SpawningObjectTypeEnum enemySpawnType()
    {
        int _randomIndex = UnityEngine.Random.Range(0, 5);
        switch (_randomIndex)
        {
            case 0:
                return SpawningObjectTypeEnum.BarrierEnemySpawn;
            case 1:
                return SpawningObjectTypeEnum.LaserEnemySpawn;
            case 2:
                return SpawningObjectTypeEnum.Gold;
            case 3:
                return SpawningObjectTypeEnum.Rocket;
            default:
                return SpawningObjectTypeEnum.Delay;
        }
    }

}
public class SpawnerControllerGoldSpawnState : IState
{
    SpawnerController _spawnerController;
    float _currentSpawnTime = 0;
    public SpawnerControllerGoldSpawnState(SpawnerController spawnerController)
    {
        _spawnerController = spawnerController;

    }
    public void EnterState()
    {

        for (int i = 0; i < 5; i++)
        {
            _spawnerController.GoldSpawner.OneCoinSpawn();

        }

        _currentSpawnTime = 0;
    }

    public void ExitState()
    {



    }

    public void UpdateState()
    {
        _currentSpawnTime += Time.deltaTime;
        if (_currentSpawnTime > 5)
        {
            _spawnerController.SpawnerControllerChangeState(SpawningObjectTypeEnum.Delay);

        }
        Debug.Log("Gold Update");

    }
}
public class SpawnerControllerNotSpawnState : IState
{
    protected SpawnerController _enemyManager;
    public SpawnerControllerNotSpawnState(SpawnerController enemyManager)
    {
        _enemyManager = enemyManager;
    }
    public void EnterState()
    {

    }

    public void ExitState()
    {

    }

    public void UpdateState()
    {
        Debug.Log("Not Spawn Update");
        if (GameManager.Instance.GameManagerState == GameManagerState.GameState)
        {
            _enemyManager.SpawnerControllerChangeState(SpawningObjectTypeEnum.Delay);
        }
    }


}

public class SpawnerControllerRocketSpawnState : IState
{
    SpawnerController _spawnerControllerRocketSpawnService;

    float _timer = 0;
    private bool _canSpawn = false;
    public SpawnerControllerRocketSpawnState(SpawnerController spawnerControllerRocketSpawnService) => _spawnerControllerRocketSpawnService = spawnerControllerRocketSpawnService;

    public void EnterState()
    {
        _timer = 0;
        _spawnerControllerRocketSpawnService.RocketSpawner.ChangeAlertVisibility(true);
    }

    public void ExitState()
    {
        _spawnerControllerRocketSpawnService.RocketSpawner.ChangeAlertVisibility(false);
        _canSpawn = false;
        _spawnerControllerRocketSpawnService.RocketSpawner.AlertController.AlertVerticalMove.StopMove();

    }

    public void UpdateState()
    {
        _spawnerControllerRocketSpawnService.RocketSpawner.AlertController.AlertVerticalMove.PlayMove();
        _timer += Time.deltaTime;
        if (_timer > 3)
        {
            _spawnerControllerRocketSpawnService.RocketSpawner.Spawn();
            _spawnerControllerRocketSpawnService.SpawnerControllerChangeState(SpawningObjectTypeEnum.Delay);

        }
    }
}