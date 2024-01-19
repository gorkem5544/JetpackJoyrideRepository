public interface ISpawnerControllerBarrierSpawnService : ISpawnerControllerChangeStateService, ISpawnerControllerStateMachineService
{
    BarrierSpawner BarrierSpawner { get; }
}
