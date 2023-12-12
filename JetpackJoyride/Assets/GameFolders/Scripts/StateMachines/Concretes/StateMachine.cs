using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Concretes
{
    public class StateMachine : IStateMachine
    {
        List<StateTransition> _normalStateTransition = new List<StateTransition>();
        List<StateTransition> _anyStateTransition = new List<StateTransition>();
        IState _currentState;

        public void SetState(IState state)
        {
            _currentState?.ExitState();
            _currentState = state;
            _currentState.EnterState();
        }


        public void UpdateTick()
        {
            IState state = CheckState();
            if (state != null)
            {
                SetState(state);
            }

            _currentState.UpdateState();
        }

        private IState CheckState()
        {
            foreach (StateTransition anyStateTransition in _anyStateTransition)
            {
                if (anyStateTransition.Condition.Invoke())
                {
                    return anyStateTransition.To;
                }
            }
            foreach (StateTransition stateTransition in _normalStateTransition)
            {
                if (stateTransition.Condition.Invoke() && stateTransition.From.Equals(_currentState))
                {
                    return stateTransition.To;
                }
            }

            return null;
        }
        public void SetNormalStateTransitions(IState from, IState to, System.Func<bool> condition)
        {
            _normalStateTransition.Add(new StateTransition(from, to, condition));
        }
        public void SetAnyStateTransitions(IState to, System.Func<bool> condition)
        {
            _anyStateTransition.Add(new StateTransition(null, to, condition));
        }
    }

}
public interface IStateTransition
{
    public IState From { get; }
    public IState To { get; }
    public System.Func<bool> Condition { get; }
}
public class StateTransition : IStateTransition
{
    IState _from;
    IState _to;
    System.Func<bool> _condition;

    public StateTransition(IState from, IState to, Func<bool> condition)
    {
        From = from;
        To = to;
        Condition = condition;
    }

    public IState From { get => _from; set => _from = value; }
    public IState To { get => _to; set => _to = value; }
    public Func<bool> Condition { get => _condition; set => _condition = value; }
}