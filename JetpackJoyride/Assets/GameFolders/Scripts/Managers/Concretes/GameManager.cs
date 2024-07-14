using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Concretes;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class GameManager : SingletonDontDestroyMonoObject<GameManager>, IGameManager
    {
        GameManagerStateEnum _gameManagerState;
        StateMachine _stateMachine;
        public GameManagerStateEnum GameManagerState { get => _gameManagerState; set => _gameManagerState = value; }

        protected override void Awake()
        {
            base.Awake();
            _stateMachine = new StateMachine();
        }

        private void Start()
        {
            GameManagerMenuState _menuState = new GameManagerMenuState();
            GameManagerGameState _gameState = new GameManagerGameState();
            GameManagerGameOverState _gameOverState = new GameManagerGameOverState();

            _stateMachine.SetState(_menuState);

            _stateMachine.SetNormalStateTransitions(_menuState, _gameState, () => GameManagerState == GameManagerStateEnum.GameState);
            _stateMachine.SetNormalStateTransitions(_gameState, _gameOverState, () => _gameManagerState == GameManagerStateEnum.GameOverState);

            _stateMachine.SetNormalStateTransitions(_gameOverState, _menuState, () => _gameManagerState == GameManagerStateEnum.MenuState);

            _stateMachine.SetNormalStateTransitions(_gameOverState, _gameState, () => _gameManagerState == GameManagerStateEnum.GameState);

        }
        private void Update()
        {
            _stateMachine.Update();
        }
        public void ChangeGameState(GameManagerStateEnum gameManagerState)
        {
            GameManagerState = gameManagerState;
        }
    }

}

