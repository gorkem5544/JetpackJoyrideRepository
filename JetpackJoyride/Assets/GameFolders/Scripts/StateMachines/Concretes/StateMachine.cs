using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Concretes
{

    public class StateMachine
    {
        private List<StateTransition> _stateTransitions = new List<StateTransition>();
        private List<StateTransition> _anyStateTransitions = new List<StateTransition>();
        private IState _currentState;
        private Dictionary<GameManagerStateEnum, IState> _states = new Dictionary<GameManagerStateEnum, IState>();

        public void AddState(GameManagerStateEnum stateEnum, IState state)
        {
            _states[stateEnum] = state;
        }

        public void SetInitialState(GameManagerStateEnum initialState)
        {
            if (_states.TryGetValue(initialState, out var state))
            {
                _currentState = state;
                _currentState.EnterState();
            }
            else
            {
                Debug.LogError($"Initial state '{initialState}' not found in the state machine.");
            }
        }

        public void SetState(IState state)
        {
            if (_currentState == state)
            {
                return;
            }

            _currentState?.ExitState();
            _currentState = state;
            _currentState.EnterState();
        }
        public void TransitionToState(GameManagerStateEnum stateEnum)
        {
            if (_states.TryGetValue(stateEnum, out var newState))
            {
                _currentState.ExitState();
                _currentState = newState;
                _currentState.EnterState();
            }
            else
            {
                Debug.LogError($"State '{stateEnum}' not found in the state machine.");
            }
        }

        public void Update()
        {
            var transition = CheckForTransition();
            if (transition != null)
            {
                SetState(transition.To);
            }
            _currentState?.UpdateState();
        }

        private StateTransition CheckForTransition()
        {
            foreach (var anyTransition in _anyStateTransitions)
            {
                if (anyTransition.Condition())
                {
                    return anyTransition;
                }
            }
            foreach (var transition in _stateTransitions)
            {
                if (transition.Condition() && transition.From == _currentState)
                {
                    return transition;
                }
            }
            return null;
        }

        public void SetNormalStateTransitions(IState from, IState to, Func<bool> condition)
        {
            var transition = new StateTransition(from, to, condition);
            _stateTransitions.Add(transition);
        }

        public void AddAnyStateTransition(IState to, Func<bool> condition)
        {
            var transition = new StateTransition(null, to, condition);
            _anyStateTransitions.Add(transition);
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