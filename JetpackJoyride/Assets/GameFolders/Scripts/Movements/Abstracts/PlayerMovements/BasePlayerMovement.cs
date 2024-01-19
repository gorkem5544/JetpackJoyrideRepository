using Unity.Mathematics;
using UnityEngine;

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
        if (_playerController.transform.position.y >= YTransform || _playerController.transform.position.y <= -YTransform)
        {
            _playerController.Rigidbody2D.velocity = Vector2.zero;
        }
    }

}


