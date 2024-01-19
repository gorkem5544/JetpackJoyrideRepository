using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;

public class GameManagerMenuState : IState
{
    public void EnterState()
    {
        GoldManager.Instance.PlayerPrefsGetScore();
        GoldManager.Instance.SumGameAndMenuScore();
    }

    public void ExitState()
    {
    }

    public void UpdateState()
    {
    }
}

