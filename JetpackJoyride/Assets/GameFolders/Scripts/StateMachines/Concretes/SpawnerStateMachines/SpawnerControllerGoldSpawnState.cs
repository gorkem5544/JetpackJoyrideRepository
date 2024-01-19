public class SpawnerControllerGoldSpawnState : AbstractSpawnerControllerTimeDependentState
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
