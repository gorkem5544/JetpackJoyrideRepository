public interface ISpawnerControllerLaserSpawnService : ISpawnerControllerChangeStateService, ISpawnerControllerStateMachineService
{
    LaserSpawner LaserSpawner { get; }
}
