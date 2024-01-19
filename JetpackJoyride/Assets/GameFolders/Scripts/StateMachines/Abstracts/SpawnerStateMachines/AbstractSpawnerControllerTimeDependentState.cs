using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using UnityEngine;

public abstract class AbstractSpawnerControllerTimeDependentState : IState
{
    protected float _currentTime;

    public virtual void EnterState()
    {
        _currentTime = 0;
    }

    public virtual void ExitState()
    {
        _currentTime = 0;
    }

    public virtual void UpdateState()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > MaxTime())
        {
            Action();
        }
    }
    protected abstract float MaxTime();
    protected abstract void Action();
}