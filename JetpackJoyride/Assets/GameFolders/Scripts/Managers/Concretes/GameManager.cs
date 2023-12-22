using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Concretes;
using UnityEngine;

public enum GameManagerState
{
    MenuState, GameState, GameOverState
}

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class GameManager : SingletonDontDestroyMonoObject<GameManager>
    {

        GameManagerState _gameManagerState;
        IStateMachine _stateMachine;
        [SerializeField] PlayerDetailSO playerDetailSO;
        [SerializeField] PlayerDetailListSO playerDetailListSO;
        [SerializeField] PlayerController _playerController;

        PlayerController playerController { get; set; }
        public GameManagerState GameManagerState { get => _gameManagerState; set => _gameManagerState = value; }

        protected override void Awake()
        {
            base.Awake();
            _stateMachine = new StateMachine();
        }

        private void Start()
        {
            MenuState _menuState = new MenuState();
            GameState _gameState = new GameState();
            GameOverState _gameOverState = new GameOverState(this);

            _stateMachine.SetState(_menuState);

            _stateMachine.SetNormalStateTransitions(_menuState, _gameState, () => GameManagerState == GameManagerState.GameState);
            _stateMachine.SetNormalStateTransitions(_gameState, _gameOverState, () => _gameManagerState == GameManagerState.GameOverState);

            _stateMachine.SetNormalStateTransitions(_gameOverState, _menuState, () => _gameManagerState == GameManagerState.MenuState);
            //_stateMachine.SetNormalStateTransitions(_gameState, _menuState, () => _gameManagerState == GameManagerState.MenuState);

            _stateMachine.SetNormalStateTransitions(_gameOverState, _gameState, () => _gameManagerState == GameManagerState.GameState);

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
        GoldManager.Instance.PlayerPrefsGetScore();
        GoldManager.Instance.SumGameAndMenuScore();
    }

    public void ExitState()
    {

    }

    public void UpdateState()
    {
        Debug.Log("Menu Update");

    }
}
public class GameState : IState
{
    public void EnterState()
    {

    }

    public void ExitState()
    {

    }

    public void UpdateState()
    {
        Debug.Log("Game Update");

    }
}

public class GameOverState : IState
{
    GameManager _gameManager;
    float _timer = 0;
    public GameOverState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public void EnterState()
    {
        _timer = 0;
    }

    public void ExitState()
    {
        _timer = 0;
    }

    public void UpdateState()
    {
        Debug.Log("Dead Update");
    }
}