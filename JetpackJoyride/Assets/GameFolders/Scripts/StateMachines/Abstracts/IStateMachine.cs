using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using UnityEngine;
namespace Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts
{

    public interface IStateMachine
    {
        void SetNormalStateTransitions(IState from, IState to, System.Func<bool> condition);
        void SetAnyStateTransitions(IState to, System.Func<bool> condition);
        void UpdateTick();
        void SetState(IState state);
    }

}