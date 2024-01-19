class SpawnerControllerBarrierEnemySpawnState : AbstractSpawnerControllerTimeDependentState
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
        return 10;
    }
}
