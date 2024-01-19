using UnityEngine;

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


