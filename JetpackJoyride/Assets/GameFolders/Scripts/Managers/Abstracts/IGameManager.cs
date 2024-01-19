public interface IGameManager
{
    public GameManagerStateEnum GameManagerState { get; set; }
    void ChangeGameState(GameManagerStateEnum gameManagerState);
}

