public class SpawnerControllerRocketSpawnState : AbstractSpawnerControllerTimeDependentState
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
