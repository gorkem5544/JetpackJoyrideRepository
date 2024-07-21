public class SpawnerControllerDelayState : AbstractSpawnerControllerTimeDependentState
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
        int _randomIndex = UnityEngine.Random.Range(0, 7);
        switch (_randomIndex)
        {
            case 0:
                return SpawningObjectTypeEnum.Rocket;
            case 1:
                return SpawningObjectTypeEnum.Rocket;
            case 2:
                return SpawningObjectTypeEnum.Rocket;
            case 3:
                return SpawningObjectTypeEnum.Rocket;
            case 4:
                return SpawningObjectTypeEnum.Rocket;
            case 5:
                return SpawningObjectTypeEnum.Rocket;
            case 6:
                return SpawningObjectTypeEnum.Rocket;
            default:
                return SpawningObjectTypeEnum.Delay;
        }
    }

}
