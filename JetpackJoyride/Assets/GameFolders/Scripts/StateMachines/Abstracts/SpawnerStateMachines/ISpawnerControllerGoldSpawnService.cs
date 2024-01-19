public interface ISpawnerControllerGoldSpawnService : ISpawnerControllerChangeStateService, ISpawnerControllerStateMachineService
{
    GoldSpawner GoldSpawner { get; }
}
