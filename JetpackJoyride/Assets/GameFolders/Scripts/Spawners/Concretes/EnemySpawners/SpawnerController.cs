using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Concretes;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class SpawnerController : MonoBehaviour, ISpawnerControllerBarrierSpawnService, ISpawnerControllerLaserSpawnService, ISpawnerControllerRocketSpawnService, ISpawnerControllerGoldSpawnService
    {
        StateMachine _spawnerControllerStateMachine;
        BarrierSpawner _barrierSpawner;
        LaserSpawner _laserSpawner;
        GoldSpawner _goldSpawner;
        [SerializeField] RocketSpawner _rocketSpawner;
        SpawningObjectTypeEnum _spawningObjectTypeEnum;
        [SerializeField] Transform[] _spawnTransforms;

        public StateMachine SpawnerControllerStateMachine => _spawnerControllerStateMachine;
        public BarrierSpawner BarrierSpawner => _barrierSpawner;
        public LaserSpawner LaserSpawner => _laserSpawner;
        public GoldSpawner GoldSpawner => _goldSpawner;
        public RocketSpawner RocketSpawner => _rocketSpawner;

        IStateMachine ISpawnerControllerStateMachineService.SpawnerControllerStateMachine => throw new NotImplementedException();

        private void Awake()
        {
            _barrierSpawner = new BarrierSpawner(_spawnTransforms);
            _laserSpawner = new LaserSpawner(_spawnTransforms);
            _goldSpawner = new GoldSpawner(_spawnTransforms);
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

            _spawnerControllerStateMachine.SetNormalStateTransitions(_spawnerControllerNotSpawnState, _spawnerControllerDelayState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.Delay);

            _spawnerControllerStateMachine.SetNormalStateTransitions(_spawnerControllerDelayState, _spawnerControllerRocketSpawnState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.Rocket);
            _spawnerControllerStateMachine.SetNormalStateTransitions(_spawnerControllerRocketSpawnState, _spawnerControllerDelayState, () => _spawningObjectTypeEnum == SpawningObjectTypeEnum.Delay);


        }
        private void Update()
        {
            _spawnerControllerStateMachine.Update();

        }
        public void SpawnerControllerChangeState(SpawningObjectTypeEnum enemySpawnType) => _spawningObjectTypeEnum = enemySpawnType;

    }

}
