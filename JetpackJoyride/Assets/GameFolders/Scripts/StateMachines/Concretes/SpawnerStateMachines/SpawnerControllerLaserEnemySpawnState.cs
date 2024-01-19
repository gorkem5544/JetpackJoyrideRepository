public class SpawnerControllerLaserEnemySpawnState : AbstractSpawnerControllerTimeDependentState
{
    ISpawnerControllerLaserSpawnService _spawnerControllerLaserSpawnService;
    public SpawnerControllerLaserEnemySpawnState(ISpawnerControllerLaserSpawnService spawnerControllerLaserSpawnService)
    {
        _spawnerControllerLaserSpawnService = spawnerControllerLaserSpawnService;

    }
    public override void EnterState()
    {
        base.EnterState();

        _spawnerControllerLaserSpawnService.LaserSpawner.LaserSpawnAction();
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
