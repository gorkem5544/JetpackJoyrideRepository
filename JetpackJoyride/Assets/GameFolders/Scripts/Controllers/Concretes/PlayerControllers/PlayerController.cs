using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Combats.Concretes.PlayerCombats;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.PlayerScriptableObjects;
using UnityEngine;
public class PlayerController : MonoBehaviour, IPlayerController
{
    InputReader _input;
    [SerializeField] Rigidbody2D _rigidbody2D;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public InputReader InputReader => _input;

    PlayerHealth _playerHealth;

    [SerializeField] PlayerSO _playerSO;
    public PlayerSO PlayerSO => _playerSO;

    GoldManager _goldManger;
    public IGoldManager GoldManger => _goldManger;

    public PlayerHealth PlayerHealth => _playerHealth;
    IPlayerMovement _playerAddForceMovement;

    private void Awake()
    {
        _goldManger = new GoldManager();
        _playerHealth = GetComponent<PlayerHealth>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAddForceMovement = new PlayerRigidBodyAddForceMovement(this);
        _input = new InputReader();
    }
    private void OnValidate()
    {
        _playerHealth = GetComponent<PlayerHealth>();

    }
    private void Start()
    {
        _goldManger.PlayerPrefsGetScore();
        _goldManger.IncreaseGameInGoldAmount(123123);
    }
    private void Update()
    {
        _playerAddForceMovement.ForceUpMovementUpdateTick();
        if (Input.GetKeyDown(KeyCode.A))
        {
            _goldManger.IncreaseGameInGoldAmount(1000);
        }
    }
    private void FixedUpdate()
    {
        _playerAddForceMovement.ForceUpMovementFixedTick();
    }
    private void OnDisable()
    {
        _goldManger.PlayerPrefsGetScore();
    }
}


