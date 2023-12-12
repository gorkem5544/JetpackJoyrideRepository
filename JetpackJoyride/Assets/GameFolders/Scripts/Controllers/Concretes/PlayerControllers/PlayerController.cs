using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.PlayerScriptableObjects;
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
}
public class PlayerController : MonoBehaviour, IPlayerController
{
    InputReader _input;
    Rigidbody2D _rigidbody2D;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    public InputReader InputReader => _input;

    [SerializeField] PlayerSO _playerSO;
    public PlayerSO PlayerSO => _playerSO;

    PlayerForceUpMovement _playerForceUpMovement;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerForceUpMovement = new PlayerForceUpMovement(this);
        _input = new InputReader();
    }
    private void Update()
    {
    }
    private void FixedUpdate()
    {
        _playerForceUpMovement.ForceUpMovementFixedTick();
    }

}

public class PlayerForceUpMovement
{
    IPlayerController _playerController;
    public PlayerForceUpMovement(IPlayerController playerController)
    {
        _playerController = playerController;
    }
    public void ForceUpMovementFixedTick()
    {
        if (_playerController.InputReader.ForceUpButtonDown)
        {
            _playerController.Rigidbody2D.AddForce(Vector2.up * _playerController.PlayerSO.ForceSpeed, ForceMode2D.Impulse);
        }
    }

}
