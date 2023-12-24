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
public interface ISpawnerControllerChangeStateService
{
    void SpawnerControllerChangeState(SpawningObjectTypeEnum enemySpawnType);
}
public interface ISpawnerControllerStateMachineService
{
    IStateMachine SpawnerControllerStateMachine { get; }
}
public interface ISpawnerControllerRocketSpawnService : ISpawnerControllerChangeStateService, ISpawnerControllerStateMachineService
{
    RocketSpawner RocketSpawner { get; }
}

public interface ISpawnerControllerLaserSpawnService : ISpawnerControllerChangeStateService, ISpawnerControllerStateMachineService
{
    LaserSpawner LaserSpawner { get; }
}
public interface ISpawnerControllerGoldSpawnService : ISpawnerControllerChangeStateService, ISpawnerControllerStateMachineService
{
    GoldSpawner GoldSpawner { get; }
}

public interface ISpawnerControllerBarrierSpawnService : ISpawnerControllerChangeStateService, ISpawnerControllerStateMachineService
{
    BarrierSpawner BarrierSpawner { get; }
}

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class SpawnerController : MonoBehaviour, ISpawnerControllerBarrierSpawnService, ISpawnerControllerLaserSpawnService, ISpawnerControllerRocketSpawnService, ISpawnerControllerGoldSpawnService
    {
        IStateMachine _spawnerControllerStateMachine;
        BarrierSpawner _barrierSpawner;
        LaserSpawner _laserSpawner;
        GoldSpawner _goldSpawner;
        [SerializeField] RocketSpawner _rocketSpawner;
        SpawningObjectTypeEnum _spawningObjectTypeEnum;

        public IStateMachine SpawnerControllerStateMachine => _spawnerControllerStateMachine;
        public BarrierSpawner BarrierSpawner => _barrierSpawner;
        public LaserSpawner LaserSpawner => _laserSpawner;
        public GoldSpawner GoldSpawner => _goldSpawner;
        public RocketSpawner RocketSpawner => _rocketSpawner;


        private void Awake()
        {
            _barrierSpawner = GameObject.FindWithTag("BarrierSpawner").transform.GetComponent<BarrierSpawner>();
            _laserSpawner = GameObject.FindWithTag("LaserSpawner").transform.GetComponent<LaserSpawner>();
            _goldSpawner = GameObject.FindWithTag("GoldSpawner").transform.GetComponent<GoldSpawner>();
            _spawnerControllerStateMachine = new StateMachine();
        }
        private void Start()
        {
            SpawnerControllerBarrierEnemySpawnState _spawnerControllerBarrierEnemySpawnState = new SpawnerControllerBarrierEnemySpawnState(this);
            SpawnerControllerLaserEnemySpawnState _spawnerControllerLaserEnemySpawnState = new SpawnerControllerLaserEnemySpawnState(this);
            SpawnerControllerDelayState _spawnerControllerDelayState = new SpawnerControllerDelayState(this);
            SpawnerControllerGoldSpawnState _spawnerControllerGoldSpawnState = new SpawnerControllerGoldSpawnState(this);
            SpawnerControllerNotSpawnState _spawnerControllerNotSpawnState = new SpawnerControllerNotSpawnState(this);
            SpawnerControllerRocketSpawnState _spawnerControllerRocketSpawnState = new SpawnerControllerRocketSpawnState(this);

            _spawnerControllerStateMachine.SetState(_spawnerControllerDelayState);

            _spawnerControllerStateMachine.SetNormalStateTransitions(_spawnerControllerDelayState, _spawnerControllerBarrierEnemySpawnState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.BarrierEnemySpawn);
            _spawnerControllerStateMachine.SetNormalStateTransitions(_spawnerControllerBarrierEnemySpawnState, _spawnerControllerDelayState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.Delay);

            _spawnerControllerStateMachine.SetNormalStateTransitions(_spawnerControllerDelayState, _spawnerControllerLaserEnemySpawnState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.LaserEnemySpawn);
            _spawnerControllerStateMachine.SetNormalStateTransitions(_spawnerControllerLaserEnemySpawnState, _spawnerControllerDelayState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.Delay);

            _spawnerControllerStateMachine.SetNormalStateTransitions(_spawnerControllerDelayState, _spawnerControllerGoldSpawnState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.Gold);
            _spawnerControllerStateMachine.SetNormalStateTransitions(_spawnerControllerGoldSpawnState, _spawnerControllerDelayState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.Delay);

            _spawnerControllerStateMachine.SetAnyStateTransitions(_spawnerControllerNotSpawnState, () => GameManager.Instance.GameManagerState == GameManagerState.GameOverState);
            _spawnerControllerStateMachine.SetNormalStateTransitions(_spawnerControllerNotSpawnState, _spawnerControllerDelayState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.Delay);

            _spawnerControllerStateMachine.SetNormalStateTransitions(_spawnerControllerDelayState, _spawnerControllerRocketSpawnState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.Rocket);
            _spawnerControllerStateMachine.SetNormalStateTransitions(_spawnerControllerRocketSpawnState, _spawnerControllerDelayState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.Delay);


        }
        private void Update()
        {
            _spawnerControllerStateMachine.UpdateTick();

        }
        public void SpawnerControllerChangeState(SpawningObjectTypeEnum enemySpawnType) => _spawningObjectTypeEnum = enemySpawnType;

    }

}
class SpawnerControllerBarrierEnemySpawnState : BaseTimeDependentState
{
    ISpawnerControllerBarrierSpawnService _spawnerControllerBarrierSpawnService;
    public SpawnerControllerBarrierEnemySpawnState(ISpawnerControllerBarrierSpawnService spawnerControllerBarrierSpawnService)
    {
        _spawnerControllerBarrierSpawnService = spawnerControllerBarrierSpawnService;
    }
    public override void EnterState()
    {
        base.EnterState();
        _spawnerControllerBarrierSpawnService.BarrierSpawner.ResetSpawnTime();
    }

    public override void ExitState()
    {
        base.ExitState();
        _spawnerControllerBarrierSpawnService.BarrierSpawner.ResetSpawnTime();
    }

    public override void UpdateState()
    {
        _spawnerControllerBarrierSpawnService.BarrierSpawner.SpawnerUpdateTick();
        base.UpdateState();

    }

    protected override void Action()
    {
        _spawnerControllerBarrierSpawnService.SpawnerControllerChangeState(SpawningObjectTypeEnum.Delay);
    }

    protected override float MaxTime()
    {
        return 5;
    }
}
public class SpawnerControllerLaserEnemySpawnState : BaseTimeDependentState
{
    ISpawnerControllerLaserSpawnService _spawnerControllerLaserSpawnService;
    public SpawnerControllerLaserEnemySpawnState(ISpawnerControllerLaserSpawnService spawnerControllerLaserSpawnService)
    {
        _spawnerControllerLaserSpawnService = spawnerControllerLaserSpawnService;

    }
    public override void EnterState()
    {
        base.EnterState();
        _spawnerControllerLaserSpawnService.LaserSpawner.Spawn();
    }

    protected override float MaxTime()
    {
        return 5;
    }

    protected override void Action()
    {
        _spawnerControllerLaserSpawnService.SpawnerControllerChangeState(SpawningObjectTypeEnum.Delay);
    }
}
public class SpawnerControllerDelayState : BaseTimeDependentState
{
    protected ISpawnerControllerChangeStateService _spawnerControllerChangeStateService;
    public SpawnerControllerDelayState(ISpawnerControllerChangeStateService spawnerControllerChangeStateService)
    {
        _spawnerControllerChangeStateService = spawnerControllerChangeStateService;
    }

    protected override void Action()
    {
        _spawnerControllerChangeStateService.SpawnerControllerChangeState(enemySpawnType());
    }

    protected override float MaxTime()
    {
        return 5;
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
                return SpawningObjectTypeEnum.NotSpawn;
            case 3:
                return SpawningObjectTypeEnum.Rocket;
            default:
                return SpawningObjectTypeEnum.Delay;
        }
    }

}
public class SpawnerControllerGoldSpawnState : BaseTimeDependentState
{
    ISpawnerControllerGoldSpawnService _spawnerControllerGoldSpawnService;

    public SpawnerControllerGoldSpawnState(ISpawnerControllerGoldSpawnService spawnerControllerGoldSpawnService)
    {
        _spawnerControllerGoldSpawnService = spawnerControllerGoldSpawnService;
    }
    public override void EnterState()
    {
        base.EnterState();
        for (int i = 0; i < 5; i++)
        {
            _spawnerControllerGoldSpawnService.GoldSpawner.OneCoinSpawn();
        }
    }


    protected override void Action()
    {
        _spawnerControllerGoldSpawnService.SpawnerControllerChangeState(SpawningObjectTypeEnum.Delay);
    }

    protected override float MaxTime()
    {
        return 5;
    }
}
public class SpawnerControllerNotSpawnState : IState
{
    protected ISpawnerControllerChangeStateService _spawnerControllerChangeStateService;
    public SpawnerControllerNotSpawnState(ISpawnerControllerChangeStateService spawnerControllerChangeStateService) => _spawnerControllerChangeStateService = spawnerControllerChangeStateService;
    public void EnterState() { }
    public void ExitState() { }
    public void UpdateState()
    {
        if (GameManager.Instance.GameManagerState == GameManagerState.GameState)
        {
            _spawnerControllerChangeStateService.SpawnerControllerChangeState(SpawningObjectTypeEnum.Delay);
        }
    }
}

public class SpawnerControllerRocketSpawnState : BaseTimeDependentState
{
    ISpawnerControllerRocketSpawnService _spawnerControllerRocketSpawnService;

    public SpawnerControllerRocketSpawnState(ISpawnerControllerRocketSpawnService spawnerControllerRocketSpawnService) => _spawnerControllerRocketSpawnService = spawnerControllerRocketSpawnService;

    public override void EnterState()
    {
        base.EnterState();
        _spawnerControllerRocketSpawnService.RocketSpawner.ChangeAlertVisibility(true);
    }

    public override void ExitState()
    {
        base.ExitState();
        _spawnerControllerRocketSpawnService.RocketSpawner.ChangeAlertVisibility(false);
        _spawnerControllerRocketSpawnService.RocketSpawner.AlertController.AlertVerticalMove.StopMove();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _spawnerControllerRocketSpawnService.RocketSpawner.AlertController.AlertVerticalMove.PlayMove();
    }

    protected override void Action()
    {
        _spawnerControllerRocketSpawnService.RocketSpawner.Spawn();
        _spawnerControllerRocketSpawnService.SpawnerControllerChangeState(SpawningObjectTypeEnum.Delay);
    }

    protected override float MaxTime()
    {
        return 3;
    }
}
public abstract class BaseTimeDependentState : IState
{
    protected float _currentTime;

    public virtual void EnterState()
    {
        _currentTime = 0;
    }

    public virtual void ExitState()
    {
        _currentTime = 0;
    }

    public virtual void UpdateState()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > MaxTime())
        {
            Action();
        }
    }
    protected abstract float MaxTime();
    protected abstract void Action();
}