using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Concretes;
using UnityEngine;

public enum GameManagerState
{
    MainMenuState, PrepareState, GameState, FinalSpinState, FinalInfo, ShopMenuState, Costumes
}

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class GameManager : SingletonDontDestroyMonoObject<GameManager>
    {

        GameManagerState _gameManagerState;
        IStateMachine _stateMachine;

        public GameManagerState GameManagerState { get => _gameManagerState; set => _gameManagerState = value; }

        protected override void Awake()
        {
            base.Awake();
            _stateMachine = new StateMachine();
        }
        private void Start()
        {
            MenuState menuState = new MenuState();
            PrepareState prepareState = new PrepareState();

            _stateMachine.SetState(menuState);

            _stateMachine.SetNormalStateTransitions(menuState, prepareState, () => GameManagerState == GameManagerState.PrepareState);
            

        }
        private void Update()
        {
            _stateMachine.UpdateTick();
        }
        public void ChangeGameState(GameManagerState gameManagerState)
        {
            GameManagerState = gameManagerState;
        }
    }

}
public class MenuState : IState
{
    public void EnterState()
    {

    }

    public void ExitState()
    {

    }

    public void UpdateState()
    {

    }
}
public class PrepareState : IState
{
    public void EnterState()
    {

    }

    public void ExitState()
    {

    }

    public void UpdateState()
    {

    }
}
public class GameOverPanelState : IState
{
    public void EnterState()
    {

    }

    public void ExitState()
    {
    }

    public void UpdateState()
    {

    }
}
public class GameOverState : IState
{
    public void EnterState()
    {
        throw new System.NotImplementedException();
    }

    public void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}