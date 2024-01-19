using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using UnityEngine;

public class GameManagerGameOverState : IState
{

    public void EnterState()
    {

        PlayerManager.Instance.CurrentInstantiatePlayer.Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void ExitState()
    {

    }

    public void UpdateState()
    {
    }
}

