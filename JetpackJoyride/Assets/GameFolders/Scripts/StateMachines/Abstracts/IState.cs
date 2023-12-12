using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts
{

    public interface IState
    {
        void EnterState();
        void ExitState();
        void UpdateState();
    }

}