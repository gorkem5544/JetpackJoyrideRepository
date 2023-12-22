using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Combats.Concretes.PlayerCombats;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.PlayerScriptableObjects;
using Unity.Mathematics;
using UnityEngine;
public interface IEntityController
{
    Transform transform { get; }
}
public interface IPlayerController : IEntityController
{
    Rigidbody2D Rigidbody2D { get; }
    InputReader InputReader { get; }
    PlayerSO PlayerSO { get; }
    IGoldManger GoldManger { get; }
    PlayerHealth PlayerHealth { get; }
}
public class PlayerController : MonoBehaviour, IPlayerController
{
    InputReader _input;
    Rigidbody2D _rigidbody2D;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public InputReader InputReader => _input;

    PlayerHealth _playerHealth;

    [SerializeField] PlayerSO _playerSO;
    public PlayerSO PlayerSO => _playerSO;

    GoldManager _goldManger;
    public IGoldManger GoldManger => _goldManger;

    public PlayerHealth PlayerHealth => _playerHealth;
    IPlayerMovement _playerAddForceMovement;

    private void Awake()
    {
        _goldManger = GoldManager.Instance;
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
    }
    private void Update()
    {
        _playerAddForceMovement.ForceUpMovementUpdateTick();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // _goldManger.IncreaseGoldAmount(1);
            _goldManger.IncreaseGameInGoldAmount(1);
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

public interface IPlayerMovement
{
    void ForceUpMovementFixedTick();
    void ForceUpMovementUpdateTick();
}
public class PlayerRigidBodyAddForceMovement : BasePlayerMovement
{
    public PlayerRigidBodyAddForceMovement(IPlayerController playerController) : base(playerController)
    {
    }

    public override void ForceUpMovementFixedTick()
    {
        if (_playerController.InputReader.ForceUpButtonDown)
        {
            Vector2 force = Vector2.up * _playerController.PlayerSO.ForceSpeed;
            _playerController.Rigidbody2D.AddForce(force, ForceMode2D.Impulse);
        }
    }

}
public abstract class BasePlayerMovement : IPlayerMovement
{
    protected IPlayerController _playerController;
    float _yBoundary;
    private const int YTransform = 9;
    public BasePlayerMovement(IPlayerController playerController)
    {
        _playerController = playerController;
    }
    public abstract void ForceUpMovementFixedTick();


    public void ForceUpMovementUpdateTick()
    {
        _yBoundary = math.clamp(_playerController.transform.position.y, -YTransform, YTransform);
        _playerController.transform.position = new Vector3(_playerController.transform.position.x, _yBoundary, _playerController.transform.position.z);


        bool isPlayerOutsideBoundary = _playerController.transform.position.y >= YTransform || _playerController.transform.position.y <= -YTransform;
        if (isPlayerOutsideBoundary)
        {
            _playerController.Rigidbody2D.velocity = Vector2.zero;
        }
        //_playerController.Rigidbody2D.velocity=Mathf.Clamp
    }

}

