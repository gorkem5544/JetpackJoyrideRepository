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
                return SpawningObjectTypeEnum.LaserEnemySpawn;
            case 1:
                return SpawningObjectTypeEnum.LaserEnemySpawn;
            case 2:
                return SpawningObjectTypeEnum.LaserEnemySpawn;
            case 3:
                return SpawningObjectTypeEnum.LaserEnemySpawn;
            case 4:
                return SpawningObjectTypeEnum.LaserEnemySpawn;
            case 5:
                return SpawningObjectTypeEnum.LaserEnemySpawn;
            case 6:
                return SpawningObjectTypeEnum.LaserEnemySpawn;
            default:
                return SpawningObjectTypeEnum.Delay;
        }
    }

}
