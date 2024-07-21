using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts;
using UnityEngine;


public class GoldHorizontalMoveWithRigidBody2D : IGoldHorizontalMove
{
    private readonly IGoldHorizontalMoveService _goldHorizontalMoveService;

    public GoldHorizontalMoveWithRigidBody2D(IGoldHorizontalMoveService goldHorizontalMoveService)
    {
        _goldHorizontalMoveService = goldHorizontalMoveService;
    }

    public void FixedTick()
    {
        Vector2 vector2 = Vector2.left * _goldHorizontalMoveService.GoldController.GoldDetailScriptableObject.HorizontalMoveSpeed;
        _goldHorizontalMoveService.MoveWithRigidbody(vector2);
    }
}


public interface IGoldHorizontalMove
{
    public void FixedTick();
}

public interface IGoldHorizontalMoveService
{
    void MoveWithRigidbody(Vector2 direction);
    void MoveWithTransform(Vector2 direction);
    IGoldController GoldController { get; }
}
public class GoldHorizontalMoveService : IGoldHorizontalMoveService
{
    private readonly IGoldController _goldController;

    public GoldHorizontalMoveService(IGoldController goldController)
    {
        _goldController = goldController;
    }

    public IGoldController GoldController => _goldController;

    public void MoveWithRigidbody(Vector2 direction)
    {
        _goldController.Rigidbody2D.velocity = direction;
    }

    public void MoveWithTransform(Vector2 direction)
    {
        _goldController.transform.Translate(direction);
    }
}




public class GoldHorizontalMoveWithTransform : IGoldHorizontalMove
{
    private readonly IGoldHorizontalMoveService _goldHorizontalMoveService;

    public GoldHorizontalMoveWithTransform(IGoldHorizontalMoveService goldHorizontalMoveService)
    {
        _goldHorizontalMoveService = goldHorizontalMoveService;
    }

    public void FixedTick()
    {
        _goldHorizontalMoveService.MoveWithTransform(Vector2.left);
    }
}