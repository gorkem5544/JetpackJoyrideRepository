public interface ISpawnerControllerRocketSpawnService : ISpawnerControllerChangeStateService, ISpawnerControllerStateMachineService
{
    RocketSpawner RocketSpawner { get; }
}
