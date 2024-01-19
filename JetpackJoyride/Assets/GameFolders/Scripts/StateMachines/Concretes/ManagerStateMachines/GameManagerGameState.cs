using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using UnityEngine;

public class GameManagerGameState : IState
{
    public void EnterState()
    {
        PlayerManager.Instance.CurrentInstantiatePlayer.Rigidbody2D.constraints = RigidbodyConstraints2D.None;
    }

    public void ExitState()
    {

    }

    public void UpdateState()
    {
    }
}

