using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;

public class SpawnerControllerNotSpawnState : IState
{
    protected ISpawnerControllerChangeStateService _spawnerControllerChangeStateService;
    public SpawnerControllerNotSpawnState(ISpawnerControllerChangeStateService spawnerControllerChangeStateService) => _spawnerControllerChangeStateService = spawnerControllerChangeStateService;
    public void EnterState() { }
    public void ExitState() { }
    public void UpdateState()
    {
        if (GameManager.Instance.GameManagerState == GameManagerStateEnum.GameState)
        {
            _spawnerControllerChangeStateService.SpawnerControllerChangeState(SpawningObjectTypeEnum.Delay);
        }
    }
}
